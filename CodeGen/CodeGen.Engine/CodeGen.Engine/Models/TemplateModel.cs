using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Engine.Models
{
    public class TemplateCollectionModel
    {
        public TemplateCollectionModel()
        {
            Templates = new Dictionary<string, string>();
        }
        public string CollectionName { get; set; }
         
        public Dictionary<string,string> Templates { get; set; }
    }
}
