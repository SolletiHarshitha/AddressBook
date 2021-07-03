using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class CreateContactBooks
    {
        public static int count = 0;
        public static Dictionary <string,ContactBook> contactBookList;

        public CreateContactBooks()
        {
            contactBookList = new Dictionary<string, ContactBook>();
        }
        //Adding contact book
        public static void AddContactBook(string bookName,ContactBook book)
        {

            contactBookList.Add(bookName,book);
            count++;
        }
        public bool FindByName(string bookName)
        {
            bool r = contactBookList.ContainsKey(bookName); 
            return r;
        }
    }
}
