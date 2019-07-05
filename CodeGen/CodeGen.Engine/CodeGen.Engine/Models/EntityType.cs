using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Engine.Models
{
    public class EntityType
    {
        public EntityType()
        {
            Properties = new List<EntityProperty>();
        }
        public string Name { get; set; }

        public List<EntityProperty> Properties { get; set; }
    }
}
