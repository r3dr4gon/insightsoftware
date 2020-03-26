using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXO.ProgrammingAssignments.ORM.Models
{
    public interface IDbObject
    {
        string InsertCommand();
        string UpdateCommand();
    }
}
