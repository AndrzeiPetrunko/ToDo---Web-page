
   using ToDo.Repository;
namespace ToDo.Extension 
{
    public static class ToDoListExtension
    {
        public static IServiceCollection AddToDoServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IToDoRepository, ToDoRepository>();
            serviceCollection.AddDbContext<ToDoDbContext, ToDoDbContext>();
            return serviceCollection;
        }
    }
}
    

