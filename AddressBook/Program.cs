using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        public static string bookName;
        // Dictionary for Contacts which are in same City ......
        public static Dictionary<string, List<ContactDetails>> CityWiseContacts = new Dictionary<string, List<ContactDetails>>();
        // Dictionary for Contacts which are in same State......
        public static Dictionary<string, List<ContactDetails>> StateWiseContacts = new Dictionary<string, List<ContactDetails>>();
       


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            ContactBook book = new ContactBook();
            CreateContactBooks ccb = new CreateContactBooks();
            ContactDetails cd = new ContactDetails();
            bool end = false;
            int option;
            while (!end)
            {
                Console.WriteLine("1.Add contack book\n2.Work with exisiting contact book\n3.View contact by city or state");
                Console.WriteLine("Choose an option");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //choosing an address book
                        Console.WriteLine("Enter name of the contact book :");
                        bookName = Console.ReadLine();
                        bool result = ccb.FindByName(bookName);
                        if (result)
                        {
                            Console.WriteLine("The book exists..");
                        }
                        else
                        {
                            Console.WriteLine("Book does not exists. So creating that book");
                            ccb.AddContactBook(bookName, book);
                            Operations();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter name of the contact book yow want work with ");
                        bookName = Console.ReadLine();
                        Operations();
                        break;
                    case 3:
                        ViewContactByCityOrState();
                        break;
                }
            }
        }
        public static void Operations()
        {
            ContactBook book = new ContactBook();
            ContactDetails cd = new ContactDetails();
            bool end = false;
            while (!end)
            {
                //Choosing option
                Console.WriteLine("Choose an option to perform in " + bookName + " : ");
                Console.WriteLine("1.Adding the contact details to Address Book");
                Console.WriteLine("2.Edit the contact details");
                Console.WriteLine("3.Delete the contact details");
                Console.WriteLine("4.Number of contacts in address book");
                Console.WriteLine("5.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //Adding contact details
                        //ContactDetails cd = new ContactDetails();
                        Console.WriteLine("Enter a name :");
                        string names = Console.ReadLine();
                        int index = book.FindByName(names);
                        if (index == -1)
                        {
                            Console.WriteLine("The name with that contact does not exist so I am adding it....");
                            cd.ReadInput();
                            book.AddContact(cd);
                            AddCityOrState(cd);
                            Console.WriteLine("Contact updated successfully in " + bookName);
                        }
                        else
                        {
                            Console.WriteLine("Contact already exists in " + bookName);
                        }
                        break;
                    case 2:
                        //Editing contact details
                        Console.WriteLine("Enter the name of a contact you wish to edit in " + bookName + " : ");
                        string name = Console.ReadLine();
                        int index2 = book.FindByName(name);
                        if (index2 == -1)
                        {
                            Console.WriteLine("No contact exists with that name..");
                        }
                        else
                        {
                            Console.WriteLine("Contact exists. Now you can edit it..");
                            //ContactDetails cd2 = new ContactDetails();
                            cd.ReadInput();
                            book.contactList[index2] = cd;
                            Console.WriteLine("Contact Details updated successfully in " + bookName);
                        }
                        break;
                    case 3:
                        //Deleting contact details
                        Console.WriteLine("Enter the first name of a contact you wish to delete in " + bookName + " : ");
                        string firstname = Console.ReadLine();
                        int index3 = book.FindByName(firstname);
                        if (index3 == -1)
                        {
                            Console.WriteLine("No contact exists with that name..");
                        }
                        else
                        {
                            book.DeleteContact(index3);
                            Console.WriteLine("Contact Details deleted successfully in " + bookName);
                        }
                        break;
                    case 4:
                        //Printing count of contacts
                        Console.WriteLine("Count of contacts in " + bookName + " : " + ContactBook.cnt);
                        break;
                    case 5:
                        //Exit
                        end = true;
                        break;
                    default:
                        break;
                }
            }
            //Printing count of contact books
            Console.WriteLine("Number of contact books : " + CreateContactBooks.count);
        }
        
        public static void AddCityOrState(ContactDetails cd)
        {
            if (!CityWiseContacts.ContainsKey(cd.city))
            {
                List<ContactDetails> cityContact = new List<ContactDetails>();
                cityContact.Add(cd);
                CityWiseContacts.Add(cd.city, cityContact);
            }
            else
            {
                List<ContactDetails> cityContact = CityWiseContacts[cd.city];
                cityContact.Add(cd);
            }
            if (!StateWiseContacts.ContainsKey(cd.state))
            {
                List<ContactDetails> stateContact = new List<ContactDetails>();
                stateContact.Add(cd);
                StateWiseContacts.Add(cd.state, stateContact);
            }
            else
            {
                List<ContactDetails> stateContact = StateWiseContacts[cd.state];
                stateContact.Add(cd);
            }
        }
        public static void ViewContactByCityOrState()
        {
            ContactDetails cd = new ContactDetails();
            int choice;
            Console.WriteLine(" 1.View Person Contact By City \n 2.View Person Contact By State");
            Console.Write("\n Select Options : ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the city name : ");
                    string cityName = Console.ReadLine();
                    List<ContactDetails> cityContact = CityWiseContacts[cityName];
                    Console.WriteLine("\n Contacts in the " + cityName + " City");
                    foreach (ContactDetails contact in cityContact)
                    {
                        ContactDetails.DisplayContact(contact);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the state name : ");
                    string stateName = Console.ReadLine();
                    List<ContactDetails> stateContact = StateWiseContacts[stateName];
                    Console.WriteLine("\n Contacts in the " + stateName + " State");
                    foreach (ContactDetails contact in stateContact)
                    {
                        ContactDetails.DisplayContact(contact);
                    }
                    break;
            }
        }
    }
}
    


       



            