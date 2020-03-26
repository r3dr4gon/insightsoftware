using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXO.ProgrammingAssignments.ORM.Models
{
    public class ProtaDbObject : DbObject
    {
        public ProtaDbObject(object obj) : base(obj)
        {
        }

        protected override string Decorator(string str)
        {
            return str;
        }
    }
}
