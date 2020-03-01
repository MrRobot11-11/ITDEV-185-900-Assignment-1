using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lantz_Generics
{
    class MyGeneric<T> where T: IComparable
    {

        

        public bool CompareTwoValues<T>(T value1, T value2)

        {
            if (EqualityComparer<T>.Default.Equals(value1, value2))
            {
                Console.WriteLine("\nThe two values are equal!");
                return true;
            }

            else
            {
                Console.WriteLine("\nThe values are not equal.");
                return false;
            }
                
        }

     
      
    }
}
