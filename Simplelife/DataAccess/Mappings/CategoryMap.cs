using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Simplelife.Models;

namespace Simplelife.DataAccess.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");
            HasMany(x => x.Notes);
            HasKey(x => x.Id);
        }
    }
}