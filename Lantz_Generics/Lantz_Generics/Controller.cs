using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lantz_Generics
{

    
    class Controller
    {
        View vw = new View();

      public void RunProgram()
        {
            vw.Intro();
            
            do
            {
                Console.ReadLine();
                Console.Clear();



                vw.Menu();

                string input = Console.ReadLine();

                if (input == "1")
                {
                    MyGeneric<int> compare = new MyGeneric<int>();
                    compare.CompareTwoValues(int.Parse(vw.GetFirstValueString()), int.Parse(vw.GetSecondValueString()));
                }

                if (input == "2")
                {
                    MyGeneric<string> compare2 = new MyGeneric<string>();
                    compare2.CompareTwoValues(vw.GetFirstValueString(), vw.GetSecondValueString());
                }

                
            } while (!vw.MoreComparisons());

      
        }//End of RunProgram

      
        
    }//End of class
    
}//End of namespace
