using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saphyre.Contact.Model;
using Saphyre.Contact.Context.EntityConfiguration;

namespace Saphyre.Contact.Context
{

    public class ContactContext : DbContext
    {

        #region constructors
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        { }

        #endregion


        #region properties
        public virtual DbSet<Model.Contact> Contacts { get; set; }

        #endregion


        #region methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new ContactConfiguration());

        }

        public void init()
        {
            for (int i = 0; i <= 9; i++)
            {
                var contact1 = new Contact.Model.Contact()
                {

                    id = Guid.NewGuid(),
                    firstName = "John" + i,
                    lastName = "Dough" + i,
                    address = "123 Sample drive, NJ 08016",
                    phone = "732897654" + i,
                    age = 20 + i
               
                 };
                this.Contacts.Add(contact1);
            }

            this.SaveChanges();

    }


    #endregion
}
}
