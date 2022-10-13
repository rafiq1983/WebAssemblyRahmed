using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saphyre.Contact.Context.EntityConfiguration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Model.Contact>
    {
        public void Configure(EntityTypeBuilder<Model.Contact> builder)
        {

            builder.ToTable("Contacts", "dbo").HasKey(c => c.id);
            builder.Property(c => c.id).HasColumnName("id").ValueGeneratedNever();
            builder.Property(c => c.firstName).HasColumnName("FirstName");
            builder.Property(c => c.lastName).HasColumnName("LastName");
            builder.Property(c => c.age).HasColumnName("Age");
            builder.Property(c => c.address).HasColumnName("Address");
            builder.Property(c => c.phone).HasColumnName("Phone");

        }
    }
}
