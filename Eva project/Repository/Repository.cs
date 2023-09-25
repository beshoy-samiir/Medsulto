using Eva_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Eva_project.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<T> GetAll(string includes = null)
        {
            return includes == null ?
                context.Set<T>().ToList() :
                context.Set<T>().Include(includes).ToList();
        }
        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}
