using Microsoft.EntityFrameworkCore;
using ToDo.Entities;

namespace ToDo
{
    public class ToDoDbContext : DbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskPriorityCategory> PriorityCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public ToDoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=ToDo;MultipleActiveResultSets=true;trusted_connection=true;", x => x.MigrationsHistoryTable("__EFMigrationsHistory", "ToDo"));
        }
    }
}
