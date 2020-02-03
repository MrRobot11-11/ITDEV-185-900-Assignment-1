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
    class Honda : Car
    {

//Fields
        private string carManufacturer = "Honda";
        private string model;
        private string engineType;
        private string amenity;
        private LuxuryorStandard luxuryorStandard;

//Constructor w/four parameters
        public Honda(string carType, int carYear, LuxuryorStandard luxuryorStandard, string model, string engineType)
            :base (carType, carYear)//Base constructor arguments
        {
            this.LuxuryorStandard1 = luxuryorStandard;
            this.model = model;
            this.engineType = engineType;
        }

//Default constructor
        public Honda()
        {
        }

//Enum declaration
      public enum LuxuryorStandard
        {
            Luxury , Standard 
        }
        
//Accessors/mutators
        public string CarManufacturer { get => carManufacturer; set => carManufacturer = value; }

        internal LuxuryorStandard LuxuryorStandard1 { get => luxuryorStandard; set => luxuryorStandard = value; }

        public string Model { get => model; set => model = value; }

        public string EngineType { get => engineType; set => engineType = value; }

        public string Amenity { get => amenity; set => amenity = value; }

        //Override ToString() to display car information
        public override string ToString()
        {
            return carManufacturer + "\n" + model
                          + "\n" + engineType + "\n" + LuxuryorStandard1
                         + "\n" + CarType + "\n" + CarYear;
        }


    }//End of class
}//End of namespace
