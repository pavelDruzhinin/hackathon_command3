using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Simplelife.Models;
using Simplelife.DataAccess.Mappings;


namespace Simplelife.DataAccess
{
    public class NotesContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new NoteMap());

            base.OnModelCreating(modelBuilder);
        }
        public NotesContext() : base("DefaultConnection")
        {
        }
    }
}