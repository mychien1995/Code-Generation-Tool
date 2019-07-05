namespace CodeGen.View
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadEntity = new System.Windows.Forms.Button();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.lstEntityView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.btnLoadTemplate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstTemplate = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnLoadEntity
            // 
            this.btnLoadEntity.Location = new System.Drawing.Point(713, 47);
            this.btnLoadEntity.Name = "btnLoadEntity";
            this.btnLoadEntity.Size = new System.Drawing.Size(118, 23);
            this.btnLoadEntity.TabIndex = 0;
            this.btnLoadEntity.Text = "Load Entity";
            this.btnLoadEntity.UseVisualStyleBackColor = true;
            this.btnLoadEntity.Click += new System.EventHandler(this.btnLoadEntity_Click);
            // 
            // txtConnString
            // 
            this.txtConnString.Location = new System.Drawing.Point(12, 49);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(695, 20);
            this.txtConnString.TabIndex = 1;
            // 
            // lstEntityView
            // 
            this.lstEntityView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstEntityView.FullRowSelect = true;
            this.lstEntityView.GridLines = true;
            this.lstEntityView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstEntityView.HideSelection = false;
            this.lstEntityView.Location = new System.Drawing.Point(12, 109);
            this.lstEntityView.Name = "lstEntityView";
            this.lstEntityView.Size = new System.Drawing.Size(336, 313);
            this.lstEntityView.TabIndex = 2;
            this.lstEntityView.UseCompatibleStateImageBehavior = false;
            this.lstEntityView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 400;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Entity List";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(379, 109);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtTemplate
            // 
            this.txtTemplate.Location = new System.Drawing.Point(12, 12);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(695, 20);
            this.txtTemplate.TabIndex = 6;
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Location = new System.Drawing.Point(713, 10);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(118, 23);
            this.btnLoadTemplate.TabIndex = 5;
            this.btnLoadTemplate.Text = "Load Template";
            this.btnLoadTemplate.UseVisualStyleBackColor = true;
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Template List";
            // 
            // lstTemplate
            // 
            this.lstTemplate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lstTemplate.FullRowSelect = true;
            this.lstTemplate.GridLines = true;
            this.lstTemplate.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstTemplate.HideSelection = false;
            this.lstTemplate.Location = new System.Drawing.Point(495, 109);
            this.lstTemplate.MultiSelect = false;
            this.lstTemplate.Name = "lstTemplate";
            this.lstTemplate.Size = new System.Drawing.Size(336, 313);
            this.lstTemplate.TabIndex = 7;
            this.lstTemplate.UseCompatibleStateImageBehavior = false;
            this.lstTemplate.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 400;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstTemplate);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.btnLoadTemplate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstEntityView);
            this.Controls.Add(this.txtConnString);
            this.Controls.Add(this.btnLoadEntity);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadEntity;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstEntityView;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.Button btnLoadTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstTemplate;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

