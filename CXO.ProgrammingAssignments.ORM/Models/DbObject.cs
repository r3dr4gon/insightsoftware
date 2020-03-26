using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXO.ProgrammingAssignments.ORM.Models
{
    public abstract class DbObject : IDbObject
    {
        private const string guidName = "Id";
        private string GuidName
        {
            get { return Decorator(guidName); }
        }
        private string Id { get; set; }

        private string _tableName;
        private string TableName { 
            get { return Decorator(_tableName); } 
            set { _tableName = value; }
        }

        private Dictionary<string, string> _rowData = new Dictionary<string, string>();
        public Dictionary<string, string> RowData { get => _rowData; set => _rowData = value; }
        
        public DbObject(object obj)
        {
            this.TableName = obj.GetType().Name;

            ParseDbObject(obj);

        }

        private void ParseDbObject(object obj)
        {
            this.RowData = new Dictionary<string, string>();
            var propInfo = obj.GetType().GetProperties();

            foreach (var prop in propInfo)
            {
                string name = prop.Name;
                var value = prop.GetValue(obj);

                switch (value)
                {
                    case Guid id:
                        this.Id = $"'{id}'";
                        break;
                    case string stringValue:
                        RowData.Add(name, $"'{stringValue}'");
                        break;
                    case int intValue:
                        RowData.Add(name, intValue.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        public string InsertCommand()
        {
            string columnNames = GuidName;
            string columnValues = this.Id;

            if (RowData.Count > 0)
            {
                columnNames += ", " + string.Join(",", RowData.Select(pair => Decorator(pair.Key)));
                columnValues += ", " + string.Join(",", RowData.Select(pair => pair.Value));
            }

            return $"INSERT INTO {this.TableName} ({columnNames}) VALUES ({columnValues})";
        }

        public string UpdateCommand()
        {
            if (RowData.Count > 0)
            {
                string str = string.Join(",", RowData.Select(pair => Decorator(pair.Key) + " = " + pair.Value).ToArray());
                return $"UPDATE {this.TableName} SET {str} WHERE {this.GuidName} = {this.Id}";
            }

            return null;         
        }

        protected abstract string Decorator(string str);
    }
}
