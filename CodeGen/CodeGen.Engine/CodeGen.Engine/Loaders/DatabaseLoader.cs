using CodeGen.Engine.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Engine.Loaders
{
    public interface IDatabaseLoader
    {
        DatabaseModel LoadFromConnString(string connString);
    }

    public class DatabaseLoader : IDatabaseLoader
    {
        public DatabaseModel LoadFromConnString(string connString)
        {
            var result = new DatabaseModel();
            using (var connection = new SqlConnection(connString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                var query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';";
                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var tableName = reader[0] as string;
                    var entityType = RetrieveEntity(tableName, connection);
                    result.Entities.Add(entityType);
                }
                return result;
            }
        }

        private EntityType RetrieveEntity(string tableName, SqlConnection connection)
        {
            var result = new EntityType();
            result.Name = tableName;
            if (result.Name.EndsWith("s")) result.Name = result.Name.Substring(0, result.Name.Length - 1);
             var query = $"SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}';";
            SqlCommand command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var columnName = reader[0] as string;
                var columnDataType = reader[1] as string;
                var isNullable = reader[2] as string;
                var property = new EntityProperty(columnName, columnDataType, isNullable);
                result.Properties.Add(property);
            }
            return result;
        }
    }
}
