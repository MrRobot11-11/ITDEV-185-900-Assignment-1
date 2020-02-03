using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Steven Lantz
*ITDEV-185-900
*Spring 2020
*Assignment #1: Custom Cars*/

namespace Lantz_CustomCars
{
    class Person
    {
        
//Fields
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string address;
        private string city;
        private string state;
        private string zipCode;

//Default constructor
        public Person()
        {
        }

//Constructor w/seven parameters
        public Person(string fName, string lName,string phoneNumber, 
                                    string address, string city, string state, string zipCode)
        {
            FirstName = fName;
            LastName = lName;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

//Properties
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string ZipCode { get => zipCode; set => zipCode = value; }
    }//End of class
}//End of namespace
