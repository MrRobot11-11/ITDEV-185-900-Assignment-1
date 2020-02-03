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

//Customer inherits from Person
    class Customer : Person
    {
        
//Fields
       private int idNumber;
       private int price;
        
//Default Constructor
        public Customer()
        {
        }
        
//Constructor w/nine parameters
        public Customer(string fName, string lName,string phoneNumber, 
                                            int idNumber, int price, string address, string city, string state, string zipcode)
            : base(fName, lName, phoneNumber, address, city, state, zipcode)//Base constructor arguments
        {
            IdNumber = idNumber;
            Price = price;
        }

        public int IdNumber { get => idNumber; set => idNumber = value; }
        public int Price { get => price; set => price = value; }

        //Properties


        //Override ToString() to display customer information
        public override string ToString()
        {
            return  FirstName + "\n" + LastName  
                           + "\n" + PhoneNumber + "\n" + Address
                           + "\n" + City + "\n" + State + "\n" + ZipCode
                           + "\n" + IdNumber + "\n" + Price;
        }

    }//End of class
}//End of namespace
