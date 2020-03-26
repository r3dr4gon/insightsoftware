using CXO.ProgrammingAssignments.ORM.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CXO.ProgrammingAssignments.ORM.Tests
{
    [TestClass]
    public class DbContextTest
    {
        [TestMethod]
        public void Insert_Prota_ExecutesNonEmptyCommand()
        {
            var testConnection = new TestDbConnection();
            var dbContext = new DbContext(DbType.Prota, testConnection);

            dbContext.Insert(new TestPoco());

            Assert.AreEqual(1, testConnection.ExecutedCommands.Count);
            Assert.IsFalse(string.IsNullOrEmpty(testConnection.ExecutedCommands[0]));
        }

        [TestMethod]
        public void Insert_Defteros_ExecutesNonEmptyCommand()
        {
            var testConnection = new TestDbConnection();
            var dbContext = new DbContext(DbType.Defteros, testConnection);

            dbContext.Insert(new TestPoco());

            Assert.AreEqual(1, testConnection.ExecutedCommands.Count);
            Assert.IsFalse(string.IsNullOrEmpty(testConnection.ExecutedCommands[0]));
        }

        [TestMethod]
        public void Update_Prota_ExecutesEmptyCommand()
        {
            var testConnection = new TestDbConnection();
            var dbContext = new DbContext(DbType.Prota, testConnection);

            dbContext.Update(new TestPoco());

            Assert.AreEqual(1, testConnection.ExecutedCommands.Count);
            Assert.IsTrue(string.IsNullOrEmpty(testConnection.ExecutedCommands[0]));
        }

        [TestMethod]
        public void Update_Defteros_ExecutesEmptyCommand()
        {
            var testConnection = new TestDbConnection();
            var dbContext = new DbContext(DbType.Defteros, testConnection);

            dbContext.Update(new TestPoco());

            Assert.AreEqual(1, testConnection.ExecutedCommands.Count);
            Assert.IsTrue(string.IsNullOrEmpty(testConnection.ExecutedCommands[0]));
        }

        [TestMethod]
        public void Update_Prota_ExecutesNonEmptyCommand()
        {
            var testConnection = new TestDbConnection();
            var dbContext = new DbContext(DbType.Prota, testConnection);

            dbContext.Update(new TestPoco() { Name = "name" });

            Assert.AreEqual(1, testConnection.ExecutedCommands.Count);
            Assert.IsFalse(string.IsNullOrEmpty(testConnection.ExecutedCommands[0]));
        }

        [TestMethod]
        public void Update_Defteros_ExecutesNonEmptyCommand()
        {
            var testConnection = new TestDbConnection();
            var dbContext = new DbContext(DbType.Defteros, testConnection);

            dbContext.Update(new TestPoco() { Name = "name" });

            Assert.AreEqual(1, testConnection.ExecutedCommands.Count);
            Assert.IsFalse(string.IsNullOrEmpty(testConnection.ExecutedCommands[0]));
        }
    }
}
