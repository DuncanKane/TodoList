using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public interface ITodoListData
    {
        IEnumerable<TodoList> GetAll();

        TodoList Get(int id);

        void Add(TodoList todoList);

        void Update(TodoList todoList);

        void Delete(int id);
    }

    
}
