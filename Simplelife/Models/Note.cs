using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simplelife.Models
{
    /// <summary>
    /// Заметка
    /// </summary>
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
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateData { get; set; }
        /// <summary>
        /// Аккаунт владельца заметки
        /// </summary>
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}