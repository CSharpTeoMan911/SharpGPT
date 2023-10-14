using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGPT
{
    internal class Operational_Controller
    {
        public struct Operation_Selector
        {
            public static void Operational_Controller_Method(Program.Screens screen)
            {
                switch(screen)
                {
                    case Program.Screens.Startup_Screen:
                        Initiate_Startup_Screen();
                        break;
                    case Program.Screens.Settings_Screen:
                        Initiate_Settings_Screen();
                        break;
                }
            }

            private static void Initiate_Startup_Screen()
            {
                Console.SetCursorPosition(0,0);
                GUI.Startup_Screen();
            }

            private static void Initiate_Settings_Screen()
            {
                Console.SetCursorPosition(0, 0);
                GUI.Settings_Screen();
            }
        }
    }
}
