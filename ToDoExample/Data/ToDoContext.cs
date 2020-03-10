using Microsoft.EntityFrameworkCore;
using ToDoExample.Entities;
using ToDoExample.Interfaces;

namespace ToDoExample.Data
{
    /// <summary>
    /// ToDoDbContext
    /// </summary>
    public class ToDoContext: DbContext
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="options"></param>
        public ToDoContext(DbContextOptions options) : base(options) {}

        /// <summary>
        /// ToDo情報
        /// </summary>
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
