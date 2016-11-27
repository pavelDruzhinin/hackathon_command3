using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Simplelife.Models;

namespace Simplelife.DataAccess.Mappings
{
    public class NoteMap : EntityTypeConfiguration<Note>
    {
        public NoteMap()
        {
            ToTable("Notes");
            HasKey(x => x.Id);
            HasRequired(x => x.Category);
        }
    }
}