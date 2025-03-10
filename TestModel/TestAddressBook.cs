using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CRM
{
    public class TestAddressBook
    {
        #region private attributes
        private AddressBook _addressBook;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            _addressBook = new AddressBook();
        }

        [Test]
        public void AddContacts_AddOneContact_GetContact()
        {
            //given
            Contact gauthier = new Contact("Gauthier", "Jean-Paul", new DateTime(2020, 12, 16), "espagnole", "jp@gauthier.com");

            //when
            _addressBook.AddContacts(new List<Contact> { gauthier });

            //then
            Assert.AreEqual(1, _addressBook.Contacts.Count);
        }

        [Test]
        public void AddContacts_AddMultipleContacts_GetContacts()
        {
            //given
            Contact gauthier = new Contact("Gauthier", "Jean-Paul", new DateTime(2020, 12, 16), "espagnole", "jp@gauthier.com");
            Contact astier = new Contact("Astier", "Alexandre", new DateTime(1976, 05, 12), "franšaise", "alex@astier.fr");

            //when
            _addressBook.AddContacts(new List<Contact> { gauthier, astier });

            //then
            Assert.AreEqual(2, _addressBook.Contacts.Count);
        }

        [Test]
        public void Contacts_EmptyListOfContact_GetEmptyList()
        {
            //given
            Contact gauthier = new Contact("Gauthier", "Jean-Paul", new DateTime(2020, 12, 16), "espagnole", "jp@gauthier.com");
            Contact astier = new Contact("Astier", "Alexandre", new DateTime(1976, 05, 12), "franšaise", "alex@astier.fr");

            //when
            //event is triggered during assertion

            //then
            Assert.AreEqual(0, _addressBook.Contacts.Count);
        }

        [Test]
        public void DoesExists_ContactExists_GetContact()
        {
            //given
            Contact astier = new Contact("Astier", "Alexandre", new DateTime(1976, 05, 12), "franšaise", "alex@astier.fr");
            _addressBook.AddContacts(new List<Contact> { astier });

            //when
            //event is triggered during assertion

            //then
            Assert.IsTrue(_addressBook.DoesExist(astier));
        }

        [Test]
        public void AddContacts_DuplicateFound_ThrowException()
        {
            //https://docs.nunit.org/articles/nunit/writing-tests/assertions/classic-assertions/Assert.Throws.html
            //given
            Contact gauthier = new Contact("Gauthier", "Jean-Paul", new DateTime(2020, 12, 16), "espagnole", "jp@gauthier.com");
            _addressBook.AddContacts(new List<Contact> { gauthier });

            //when
            Assert.Throws<ContactAlreadyExist>(() => _addressBook.AddContacts(new List<Contact> { gauthier }));

            //then
            //Exception thrown
        }
    }
}