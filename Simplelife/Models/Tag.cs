using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simplelife.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}