using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class SqlTodoListData : ITodoListData
    {
        private TodoListContext db;

        public SqlTodoListData(TodoListContext db)
        {
            this.db = db;
        }

        public void Add(TodoList todoList)
        {
            db.TodoItems.Add(todoList);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var todoList = db.TodoItems.Find(id);
            db.TodoItems.Remove(todoList);
            db.SaveChanges();
        }

        public TodoList Get(int id)
        {
            return db.TodoItems.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TodoList> GetAll()
        {
            return from t in db.TodoItems
                   orderby t.TaskName
                   select t;
        }

        public void Update(TodoList todoList)
        {
            var entry = db.Entry(todoList);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}