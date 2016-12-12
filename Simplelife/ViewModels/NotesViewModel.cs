using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simplelife.Models;

namespace Simplelife.ViewModels
{
    public class NotesViewModel
    {
        public IEnumerable<Note> Notes { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}