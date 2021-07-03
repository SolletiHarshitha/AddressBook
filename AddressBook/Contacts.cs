using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contacts
    {
        //Reading the contact details
        public static void ReadInput()
        {
            Console.WriteLine("Enter first name : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name : ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter address : ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter city name : ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter state name : ");
            string state = Console.ReadLine();
            Console.WriteLine("Enter zip code : ");
            int zipcode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter phone number : ");
            long phonenumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter email id : ");
            string email = Console.ReadLine();
            PrintDetails(firstName,lastName,address,city,state,zipcode,phonenumber,email);
        }

        //Printing the contact details
        private static void PrintDetails(string firstName,string lastName,string address,string city,string state,int zipcode,long phonenumber,string email)
        {
            Console.WriteLine("First name: "+firstName);
            Console.WriteLine("Last name : "+lastName);
            Console.WriteLine("Address : "+address);
            Console.WriteLine("City : "+city);
            Console.WriteLine("State : "+state);
            Console.WriteLine("Zipcode : "+zipcode);
            Console.WriteLine("Phonenumber : "+phonenumber);
            Console.WriteLine("E-mail : "+email);
        }
    }
}
