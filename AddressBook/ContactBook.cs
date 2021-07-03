﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class ContactBook
    {
        public static int cnt = 0;
        //Creating list to add contact details
        public List<ContactDetails> contactList;
        public ContactBook()
        {
            this.contactList = new List<ContactDetails>();
        }
        //Adding the contact details to address book
        public void AddContact(ContactDetails cd)
        {
            
            this.contactList.Add(cd);
            cnt++;
        }
        //Finding phone number
        public int FindByPhonenumber(long number)
        {
            return contactList.FindIndex(cd=>cd.phonenumber==number);
        }
        public int FindByName(string name)
        {
            int i = contactList.FindIndex(cd => cd.firstName.Equals(name));
            return i;
        }
    }
}