using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class TodoListContext : DbContext
    {
        //public TodoListContext() : base("todolistdb") { }

        public DbSet<TodoList> TodoItems { get; set; }
    }
}