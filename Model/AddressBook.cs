using System.Collections.Generic;
using System;

namespace CRM
{
    public class AddressBook
    {
        #region private attributes
        private List<Contact> _contacts = new List<Contact>();
        #endregion private attibutes

        #region public methods
        public void AddContacts(List<Contact> contactToAdd)
        {
            foreach (Contact contact in contactToAdd)
            {
                if (DoesExist(contact))
                {
                    throw new ContactAlreadyExist();
                }
                 else
                {
                    _contacts.AddRange(contactToAdd);
                }
            }

        }

        public bool DoesExist(Contact contact)
        {
            return _contacts.Contains(contact);
        }

        public void Remove(Contact contact)
        {
            _contacts.Remove(contact);
        }

        public List<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
        }

        public class ContactAlreadyExist : Exception { };
        #endregion public methods
    }
}
