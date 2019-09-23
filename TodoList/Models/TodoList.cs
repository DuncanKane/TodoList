using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { set; get; }
    }
}