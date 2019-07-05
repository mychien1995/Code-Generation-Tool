using CodeGen.Engine.Loaders;
using CodeGen.Engine.Models;
using CodeGen.Engine.Translators;
using CodeGen.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGen.View
{
    public partial class Form1 : Form
    {
        private readonly IDatabaseLoader _databaseLoader;
        private readonly ITemplateLoader _templateLoader;
        private readonly ITemplateTranslator _templateTranslator;
        private DatabaseModel _databaseModel;
        private TemplateCollectionModel _templateModel;

        public Form1()
        {
            InitializeComponent();
            _databaseLoader = ServiceLocator.GetInstance<IDatabaseLoader>();
            _templateLoader = ServiceLocator.GetInstance<ITemplateLoader>();
            _templateTranslator = ServiceLocator.GetInstance<ITemplateTranslator>();
        }

        private void btnLoadEntity_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _databaseModel = _databaseLoader.LoadFromConnString(txtConnString.Text);
            lstEntityView.Items.Clear();
            foreach (var entity in _databaseModel.Entities)
            {
                lstEntityView.Items.Add(new ListViewItem(new string[] { entity.Name }));
            }
            Cursor.Current = Cursors.Default;
        }

        private async void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _templateModel = await _templateLoader.LoadTemplate(txtTemplate.Text);
            lstTemplate.Items.Clear();
            foreach (var template in _templateModel.Templates)
            {
                lstTemplate.Items.Add(new ListViewItem(new string[] { template.Key }));
            }
            Cursor.Current = Cursors.Default;
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (_databaseModel != null && _templateModel != null)
            {
                var outputFolder = CreateOutputFolder();
                var selectedEntries = new List<string>();
                for (int i = 0; i < lstEntityView.SelectedItems.Count; i++)
                {
                    selectedEntries.Add(lstEntityView.SelectedItems[i].Text);
                }
                var selectedEntities = _databaseModel.Entities.Where(x => selectedEntries.Contains(x.Name));
                var taskList = new List<Task>();
                foreach (var entity in selectedEntities)
                {
                    taskList.Add(Task.Run(() =>
                    {
                        foreach (var template in _templateModel.Templates)
                        {
                            var stringContent = _templateTranslator.Translate(template.Value, entity);
                            var fileName = outputFolder + entity.Name + template.Key;
                            using (var tw = new StreamWriter(fileName, true))
                            {
                                tw.WriteLine(stringContent);
                            }
                        }
                    }));
                }
                await Task.WhenAll(taskList.ToArray()).ContinueWith(x =>
                {
                    MessageBox.Show("Done");
                });
            }
        }

        private string CreateOutputFolder()
        {
            var outputFolder = ConfigurationManager.AppSettings["OutputFolder"] ?? "../Output/";
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            var templatePath = outputFolder + _templateModel.CollectionName + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
            if (!Directory.Exists(templatePath))
            {
                Directory.CreateDirectory(templatePath);
            }
            return templatePath;

        }
    }
}
