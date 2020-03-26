using System;
using CXO.ProgrammingAssignments.ORM.Factory;
using CXO.ProgrammingAssignments.ORM.Interfaces;
using CXO.ProgrammingAssignments.ORM.Models;

namespace CXO.ProgrammingAssignments.ORM
{
    public class DbContext : IDbContext
    {
        private readonly DbType dbType;
        private readonly IDbConnection dbConnection;

        public DbContext(DbType dbType, IDbConnection dbConnection)
        {
            this.dbType = dbType;
            this.dbConnection = dbConnection;
        }

        public void Insert(object obj)
        {
            var dbObject = new DbObjectFactory().ExecuteCreation(this.dbType, obj);

            this.dbConnection.Execute(dbObject.InsertCommand());
        }

        public void Update(object obj)
        {
            var dbObject = new DbObjectFactory().ExecuteCreation(this.dbType, obj);

            this.dbConnection.Execute(dbObject.UpdateCommand());
        }
    }
}