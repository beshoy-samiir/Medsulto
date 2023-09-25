namespace Eva_project.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll(string includes = null);
        T Get(int id);
    }
}
