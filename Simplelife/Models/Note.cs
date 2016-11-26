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
        public Category Category { get; set; }
        public string Content { get; set; }
    }
}