namespace CXO.ProgrammingAssignments.ORM.Interfaces
{
    public interface IDbContext
    {
        void Insert(object obj);
        void Update(object obj);
    }
}