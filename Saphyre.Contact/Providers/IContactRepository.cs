using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saphyre.Contact.Providers
{
    /// <summary>
    /// Interface for contact repository. This gives us a flexibility to not rely on EF and easily mock for testing purpose.
    /// </summary>
    public interface IContactRepository
    {

        Boolean AddContact(Contact.Model.Contact contactObj);
        Boolean UpdateContact(Contact.Model.Contact contactObj);
        Boolean DeleteContact(Guid contactId);
        Contact.Model.Contact GetContact(Guid contactId);
        IList<Contact.Model.Contact> GetAllContacts();


    }
}
