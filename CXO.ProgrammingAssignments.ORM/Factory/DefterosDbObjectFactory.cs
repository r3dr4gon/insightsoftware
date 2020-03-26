using CXO.ProgrammingAssignments.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXO.ProgrammingAssignments.ORM.Factory
{
    class DefterosDbObjectFactory : ITypeDbObjectFactory
    {
        public IDbObject Create(object obj) => new DefterosDbObject(obj);
    }
}
