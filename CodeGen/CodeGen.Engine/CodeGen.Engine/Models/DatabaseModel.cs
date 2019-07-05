using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Engine.Models
{
    public class DatabaseModel
    {
        public DatabaseModel()
        {
            Entities = new List<EntityType>();
        }

        public List<EntityType> Entities { get; set; }
    }
}
