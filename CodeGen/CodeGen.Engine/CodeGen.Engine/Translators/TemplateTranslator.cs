using CodeGen.Engine.Extensions;
using CodeGen.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Engine.Translators
{
    public interface ITemplateTranslator
    {
        string Translate(string template, EntityType entityType);
    }

    public class TemplateTranslator : ITemplateTranslator
    {
        private const string _NameSyntax = "{{_Name}}";
        private const string _PropNameSyntax = "{{_PropName}}";
        private const string _PropertiesSyntax = "#properties";

        public string Translate(string template, EntityType entityType)
        {
            template = ReplaceDefaultField(template, entityType);
            template = ReplacePropertyLoop(template, entityType);
            return template;
        }

        private string ReplaceDefaultField(string template, EntityType entityType)
        {
            return template.Replace(_NameSyntax, entityType.Name);
        }

        private string ReplacePropertyLoop(string template, EntityType entityType)
        {
            var indexOfLoops = template.AllIndexesOf(_PropertiesSyntax);
            foreach(var loopIndex in indexOfLoops)
            {
                var contentString = template.GetPropertiesLoopContent(loopIndex);
                var translatedContent = TranslateProperty(contentString, entityType);
                template = template.RemoveUntil(loopIndex, '$', 2);
                template = template.Insert(loopIndex, translatedContent);
            }
            return template;

        }

        private string TranslateProperty(string template, EntityType entityType)
        {
            var strBuilder = new StringBuilder();
            foreach(var property in entityType.Properties)
            {
                var replacedTemplate = template.Replace(_PropNameSyntax, property.Name);
                strBuilder.Append(replacedTemplate);
            }
            return strBuilder.ToString();
        }
    }
}
