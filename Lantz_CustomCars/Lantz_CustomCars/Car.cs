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
    class Car
    {

//Fields
        private string carType;//Coupe or Sedan
        private int carYear;

//Constructor w/2 parameters
        public Car(string carType, int carYear)
        {
            this.carType = carType;
            this.carYear = carYear;
        }

//Default constructor
        public Car()
        {
        }

//Properties
        public int CarYear { get => carYear; set => carYear = value; }
        public string CarType { get => carType; set => carType = value; }

    }//End of class
   
}//End of namespace
