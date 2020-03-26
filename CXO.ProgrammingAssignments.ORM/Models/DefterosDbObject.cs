using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXO.ProgrammingAssignments.ORM.Models
{
    public class DefterosDbObject : DbObject
    {
        public DefterosDbObject(object obj) : base(obj)
        {
        }

        protected override string Decorator(string str)
        {
            return $"[{str}]";
        }
    }
}
