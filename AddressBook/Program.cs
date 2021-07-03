using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            ContactBook book = new ContactBook();
            
            int option = 1;
            //Choosing option
            while (option == 1)
            {
                Console.WriteLine("Choose an option to perform : ");
                Console.WriteLine("1.Adding the contact details to Address Book");
                Console.WriteLine("2.Exit");
                option = Convert.ToInt32(Console.ReadLine());
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
                        //Exit
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Count of contacts in address book : "+ContactBook.cnt);
        }
    }
}
