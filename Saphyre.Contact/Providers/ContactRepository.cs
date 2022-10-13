using Microsoft.EntityFrameworkCore;
using Saphyre.Contact.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saphyre.Contact.Providers
{
    public class ContactRepository : IContactRepository
    {
        #region properties
        protected ContactContext _contactContext;
        public ContactRepository(ContactContext ContactContext)
        {
            _contactContext=ContactContext;
        }
        #endregion

        #region methods
        /// <summary>
        /// Add new contact
        /// </summary>
        /// <param name="contactObj"></param>
        /// <returns></returns>
        public bool AddContact(Model.Contact contactObj)
        {
           _contactContext.Contacts.Add(contactObj);
           return Convert.ToBoolean(_contactContext.SaveChanges());
           
        }

        /// <summary>
        /// Delete contact from the system
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool DeleteContact(Guid contactId)
        {
           var isDeleted = false;
           var Contactobj = _contactContext.Contacts.Where(c => c.id == contactId).FirstOrDefault();
            if (Contactobj != null)
            {
                _contactContext.Contacts.Remove(Contactobj);
                _contactContext.SaveChanges();
                isDeleted = true;
            }

            return isDeleted;
        }

        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <returns></returns>
        public IList<Model.Contact> GetAllContacts()
        {
            return _contactContext.Contacts.ToList();
        }

        /// <summary>
        /// Get individual contact
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public Model.Contact GetContact(Guid contactId)
        {
            return _contactContext.Contacts.Where(c => c.id == contactId).FirstOrDefault();
        }

        /// <summary>
        /// Update individual contact
        /// </summary>
        /// <param name="contactObj"></param>
        /// <returns></returns>
        public bool UpdateContact(Model.Contact contactObj)
        {
            var isUpdated = false;
            var Contactobj = _contactContext.Contacts.Where(c => c.id == contactObj.id).FirstOrDefault();
            if (Contactobj != null)
            {
                Contactobj.firstName = contactObj.firstName;
                Contactobj.lastName = contactObj.lastName;
                Contactobj.age = contactObj.age;
                Contactobj.address = contactObj.address;
                Contactobj.phone = contactObj.phone;

                _contactContext.SaveChanges();
                isUpdated = true;
            }

            return isUpdated;

        }
      
        #endregion
    }
}
