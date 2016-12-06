using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simplelife.Models
{
    public class Category
    {
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор родительской категории
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список заметок в данной категории
        /// </summary>
        public List<Note> Notes { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}