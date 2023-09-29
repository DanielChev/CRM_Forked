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
                    _contacts.Add(contact);
                }
            }

        }

        public bool DoesExist(Contact contact)
        {
            return _contacts.Contains(contact);
        }

        public void Remove(Contact contact)
        {
            if (DoesExist(contact))
            {
                _contacts.Remove(contact);
            }
            else
            {
                throw new RemoveFailedException();   
            }
        }

        public List<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
        }

        public class AdressBookException : Exception { };
        public class ContactAlreadyExist : AdressBookException { };
        public class RemoveFailedException : AdressBookException { };
        #endregion public methods
    }
}
