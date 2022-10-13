
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Saphyre.Contact.Providers
{
    public class ContactProvider
    {
        #region properties
        protected IContactRepository _contactDataLayer;
        protected  ContactValidator _contactValidator;

        #endregion

        #region constructors
        public ContactProvider(IContactRepository contactDataLayer, ContactValidator validator)
        {
            _contactDataLayer = contactDataLayer;
            _contactValidator = validator;  
        }

        #endregion

        #region methods

        /// <summary>
        /// Add new contact
        /// </summary>
        /// <param name="contactObj"></param>
        /// <returns></returns>
        public ValidationResult AddContact(Model.Contact contactObj)
        {
            contactObj.id = Guid.NewGuid();
           var validObj = _contactValidator.Validate(contactObj);
            if (validObj.IsValid)
            {
                _contactDataLayer.AddContact(contactObj);
            }
            return validObj; 
        }


        /// <summary>
        /// Delete contact from the system
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ValidationResult DeleteContact(Guid contactId)
        {

            var validationResult = new ValidationResult();
            var isDeleted = _contactDataLayer.DeleteContact(contactId);
            if (isDeleted == false)
            {
                validationResult.Errors.Add(new ValidationFailure() { ErrorMessage = "Unable to delete contact" });
            }

            return validationResult;           
            
        }

        /// <summary>
        /// Get all contacts from the system
        /// </summary>
        /// <returns></returns>
        public IList<Model.Contact> GetAllContacts()
        {
            return _contactDataLayer.GetAllContacts();
        }

        /// <summary>
        /// Get individual contact from the system
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public Model.Contact GetContact(Guid contactId)
        {
            return _contactDataLayer.GetContact(contactId);
        }
        /// <summary>
        /// Update individual contact
        /// </summary>
        /// <param name="contactObj"></param>
        /// <returns></returns>
        public ValidationResult UpdateContact(Model.Contact contactObj)
        {
            var validObj = _contactValidator.Validate(contactObj);
            if (validObj.IsValid)
            {
                _contactDataLayer.UpdateContact(contactObj);
            }
            return validObj;
        }

        #endregion
    }
}
