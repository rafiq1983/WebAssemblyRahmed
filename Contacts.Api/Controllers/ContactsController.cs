using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saphyre.Contact.Model;
using Saphyre.Contact.Providers;

namespace Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        #region properties
        private ContactProvider _contactProvider { get; set; }
        #endregion

        #region methods
        public ContactsController(ContactProvider cProvider)
        {
            _contactProvider = cProvider;   
        }

        /// <summary>
        /// Gets contact by an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [ProducesResponseType(typeof(Contact),200)]
        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
           var contact =  _contactProvider.GetContact(id);
            return Ok(contact);
        }

        /// <summary>
        /// Get all the contacts from the system.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<Contact>),200)]
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var contacts = _contactProvider.GetAllContacts();
            return Ok(contacts);
        }

        /// <summary>
        /// Add new contact to the system.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(200)]
        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            var validationResult = _contactProvider.AddContact(contact);
            if (validationResult.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest(validationResult);
            }
            
        }

        /// <summary>
        /// Update individual contact in the system.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(200)]
        [HttpPut]
        public IActionResult Update(Contact contact)
        {

            var validationResult = _contactProvider.UpdateContact(contact);
            if (validationResult.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest(validationResult);
            }
        }


        /// <summary>
        /// Delete contact by its id.
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>

        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(200)]
        [HttpDelete("{contactId:Guid}")]
        public IActionResult Delete(Guid contactId)
        {

            var validationResult = _contactProvider.DeleteContact(contactId);
            if (validationResult.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest(validationResult);
            }
        }

        #endregion


    }
}
