using CodeGen.Engine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Engine.Loaders
{
    public interface ITemplateLoader
    {
        Task<TemplateCollectionModel> LoadTemplate(string path);
    }

    public class TemplateLoader : ITemplateLoader
    {
        public async Task<TemplateCollectionModel> LoadTemplate(string path)
        {
            var result = new TemplateCollectionModel();
            var collectionFolder = new DirectoryInfo(path);
            result.CollectionName = collectionFolder.Name;
            var files = collectionFolder.GetFiles("*.txt");
            var tasks = new List<Task<KeyValuePair<string, string>>>();
            foreach(var template in files)
            {
                tasks.Add(Task.Run(() => ReadTemplateFile(template)));
            }
            await Task.WhenAll(tasks.ToArray()).ContinueWith(x =>
            {
                foreach(var value in x.Result)
                {
                    result.Templates.Add(value.Key, value.Value);
                }
            });
            return result;
        }

        private KeyValuePair<string,string> ReadTemplateFile(FileInfo file)
        {
            using (StreamReader sr = file.OpenText())
            {
                StringBuilder str = new StringBuilder();
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    str.AppendLine(s);
                }
                return new KeyValuePair<string, string>(file.Name, str.ToString());
            }
        }
    }
}
