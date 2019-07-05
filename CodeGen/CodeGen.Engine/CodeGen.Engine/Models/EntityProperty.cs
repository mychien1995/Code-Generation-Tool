using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Engine.Models
{
    public class EntityProperty
    {
        private static Dictionary<string, EntityDataType> DataTypeMapping = new Dictionary<string, EntityDataType>()
        {
            { "varchar", EntityDataType.String },
            { "bigint", EntityDataType.Long },
            { "uniqueidentifier", EntityDataType.Guid },
            { "bit", EntityDataType.Boolean },
            { "datetime", EntityDataType.Datetime },
            { "nvarchar", EntityDataType.String },
            { "float", EntityDataType.Decimal },
            { "decimal", EntityDataType.Decimal },
            { "numeric", EntityDataType.Decimal }
        };

        public string Name { get; set; }

        public EntityDataType DataType { get; set; }

        public bool IsNullable { get; set; }

        public EntityProperty()
        {

        }
        public EntityProperty(string name, string dataType, string isNullable)
        {
            Name = name;
            EntityDataType datatype;
            if (DataTypeMapping.TryGetValue(dataType, out datatype))
            {
                DataType = datatype;
            }
            else DataType = EntityDataType.String;
            if (isNullable.Equals("YES", StringComparison.OrdinalIgnoreCase)) IsNullable = true;
        }
    }
}
