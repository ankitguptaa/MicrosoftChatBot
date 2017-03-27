namespace todo.Models
{
    using Bot_Application.Models;
    using System.Data.Entity;

    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
        }

        public DbSet<LUISData> Items { get; set; }
    }
}
