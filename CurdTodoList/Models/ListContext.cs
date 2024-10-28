using Microsoft.EntityFrameworkCore;

namespace CurdTodoList.Models
{
    public class ListContext : DbContext
    {
        public ListContext(DbContextOptions<ListContext> options) : base(options)
            
        {
        }
      public  DbSet<List> Lists { get; set; }
    }
}
