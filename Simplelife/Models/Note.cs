using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simplelife.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        /// <summary>
        /// Категория заметки
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// Содержимое заметки
        /// </summary>
        public string Content { get; set; }
    }
}