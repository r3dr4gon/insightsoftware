using CXO.ProgrammingAssignments.ORM.Interfaces;
using CXO.ProgrammingAssignments.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXO.ProgrammingAssignments.ORM.Factory
{
    class DbObjectFactory
    {
        private readonly Dictionary<DbType, ITypeDbObjectFactory> _factories;

        public DbObjectFactory()
        {
            _factories = new Dictionary<DbType, ITypeDbObjectFactory>();

            foreach (DbType type in Enum.GetValues(typeof(DbType)))
            {
                var factory = (ITypeDbObjectFactory)Activator.CreateInstance(Type.GetType("CXO.ProgrammingAssignments.ORM.Factory." + Enum.GetName(typeof(DbType), type) + "DbObjectFactory"));
                _factories.Add(type, factory);
            }
        }

        public IDbObject ExecuteCreation(DbType type, object obj) => _factories[type].Create(obj);
    }
}
