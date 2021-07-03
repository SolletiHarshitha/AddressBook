using System;

namespace AddressBook
{
    class Program
    {
        public static string bookName;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            ContactBook book = new ContactBook();
            CreateContactBooks ccb = new CreateContactBooks();
            bool end=false;
            //Choosing option
            while (!end)
            {
                //choosing an address book
                Console.WriteLine("Choose a contact book :");
                bookName = Console.ReadLine();
                
                bool result = ccb.FindByName(bookName);
                if(result)
                {
                    Console.WriteLine("The book exists..");
                }
                else
                {
                    Console.WriteLine("Book does not exists. So creating that book");
                    CreateContactBooks.AddContactBook(bookName,book);
                }
                Console.WriteLine("Choose an option to perform in "+bookName+" : ");
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
                            Console.WriteLine("Contact updated successfully in "+bookName);
                        }
                        else
                        {
                            Console.WriteLine("Contact already exists in "+bookName);
                        }
                        break;
                    case 2:
                        //Editing contact details
                        Console.WriteLine("Enter the name of a contact you wish to edit in "+bookName+" : ");
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
                            Console.WriteLine("Contact Details updated successfully in "+bookName);
                        }
                        break;
                    case 3:
                        //Deleting contact details
                        Console.WriteLine("Enter the first name of a contact you wish to delete in "+bookName+" : ");
                        string firstname = Console.ReadLine();
                        int index3 = book.FindByName(firstname);
                        if (index3 == -1)
                        {
                            Console.WriteLine("No contact exists with that name..");
                        }
                        else
                        {
                            book.DeleteContact(index3);
                            Console.WriteLine("Contact Details deleted successfully in "+bookName);
                        }
                        break;
                    case 4:
                        //Printing count of contacts
                        Console.WriteLine("Count of contacts in "+bookName+" : " + ContactBook.cnt);
                        break;
                    case 5:
                        //Exit
                        end = true;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Number of contact books : "+CreateContactBooks.count);
        }
    }
}
