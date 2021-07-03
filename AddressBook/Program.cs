﻿using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            ContactBook book = new ContactBook();
            
            bool end=false;
            //Choosing option
            while (!end)
            {
                Console.WriteLine("Choose an option to perform : ");
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
                        ContactDetails cd = new ContactDetails();
                        cd.ReadInput();
                        int index = book.FindByPhonenumber(cd.phonenumber);
                        if (index == -1)
                        {
                            book.AddContact(cd);
                            Console.WriteLine("Contact updated successfully");
                        }
                        else
                        {
                            Console.WriteLine("Contact already exists");
                        }
                        break;
                    case 2:
                        //Editing contact details
                        Console.WriteLine("Enter the name of a contact you wish to edit : ");
                        string name = Console.ReadLine();
                        int index2 = book.FindByName(name);
                        if(index2 == -1)
                        {
                            Console.WriteLine("No contact exists with that name..");
                        }
                        else
                        {
                            Console.WriteLine("Contact exists. Now you can edit it..");
                            ContactDetails cd2 = new ContactDetails();
                            cd2.ReadInput();
                            book.contactList[index2] = cd2;
                            Console.WriteLine("Contact Details updated successfully!");
                        }
                        break;
                    case 3:
                        //Deleting contact details
                        Console.WriteLine("Enter the first name of a contact you wish to delete : ");
                        string firstname = Console.ReadLine();
                        int index3 = book.FindByName(firstname);
                        if (index3 == -1)
                        {
                            Console.WriteLine("No contact exists with that name..");
                        }
                        else
                        {
                            book.DeleteContact(index3);
                            Console.WriteLine("Contact Details deleted successfully!");
                        }
                        break;
                    case 4:
                        //Printing count of contacts
                        Console.WriteLine("Count of contacts in address book : " + ContactBook.cnt);
                        break;
                    case 5:
                        //Exit
                        end = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
