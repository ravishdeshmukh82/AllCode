using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    public class SqlContactRepository : IContactRepository
    {
        private readonly AppDbContext context;

        public SqlContactRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Contact addContact(Contact contact)
        {
            context.Add(contact);
            context.SaveChanges();
            return contact;
        }

        public Contact deleteContact(int id)
        {
            Contact contact = context.Contacts.Find(id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }
            return contact;
        }

        public IEnumerable<Contact> getAllContacts()
        {
            return context.Contacts;
        }

        public Contact getContact(int id)
        {
            return context.Contacts.Find(id);
        }

        public Contact updateContact(Contact contact)
        {
            var con = context.Contacts.Attach(contact);
            con.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return contact;
        }
    }
}
