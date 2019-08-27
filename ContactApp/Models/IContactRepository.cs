using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    public interface IContactRepository
    {
        Contact getContact(int id);
        IEnumerable<Contact> getAllContacts();
        Contact addContact(Contact contact);
        Contact updateContact(Contact contact);
        Contact deleteContact(int id);
    }
}
