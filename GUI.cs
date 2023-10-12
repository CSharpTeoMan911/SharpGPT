using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGPT
{
    internal class GUI
    {
        private static string sharp_gpt_logo = "  .7Y5Y?^                                                                      " +
                                               " !&@@@@@B                                                                      " +
                                               ".#@@@#JJJ                                                                      " +
                                               ":&@@@~                                                                         " +
                                               ".#@@@J                                                                         " +
                                               " J@@@&:                                                                        " +
                                               " .#@@@5                                                                        " +
                                               "  7@@@@7  .YYYJ                                   ~JPGP5?:  ?YYYYYJ!.~5YYYYYY5!" +
                                               "   5@@@#. :@@@#^!!~.   ^!7!~:  :~~~:^~.~~~^^!!^  Y@@@P#@@&~ B@@@B&@@GJ&&@@@@&&?" +
                                               "   .#@@@Y :&@@&G@@@G ~#@@B@@&Y J@@@#@B7@@@#G@@@J #@@@:?@@@Y B@@@~7@@&: :&@@&^  " +
                                               "    7@@@#.:&@@#.B@@@:P@&B.B@@@:J@@@@#Y7@@@5^@@@G.#@@@~~777~ B@@@5G@@&. :&@@&:  " +
                                               "    .&@@@^.&@@#.B@@&::75GB@@@@:J@@@Y  7@@@Y^@@@G.#@@&?&@&@Y B@@@#BBP!  :&@@&:  " +
                                               ":!^^Y@@@@^.&@@#.B@@&:Y@@@!B@@@:J@@@?  7@@@Y^@@@G.#@@@:7@@@5 B@@@!      :&@@&:  " +
                                               "^@@@@@@@Y :@@@#.#@@@:G@@&~#@@@:J@@@J  7@@@P7@@@P G@@@?5@@@5 B@@@!      :@@@@:  " +
                                               ":P###BP!  .GBBP.PBBG.~G##PPBBB:7BBB7  7@@@B5##G~ .JB#&BYGBJ 5BBB~      .GBBG:  " +
                                               "   ..                  ..             ~PPP?  .      ..                         ";

        public static void Startup_Screen()
        {
            ConsoleColor default_backgound_color = Console.BackgroundColor;
            ConsoleColor default_foreground_color = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(new String(' ', Console.WindowWidth * 2));

            Print_Logo();

            Console.Write(new String(' ', Console.WindowWidth * 2));

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Print_Startup_Options();

            Console.ForegroundColor = default_foreground_color;
            Console.BackgroundColor = default_backgound_color;
        }

        private static void Print_Logo()
        {
            int remaining_width = Console.WindowWidth - 79;
            int half_remaining_width = remaining_width / 2;
            int start_logo_index = 0;
            int end_logo_index = 0;

            if (Console.WindowWidth < 85)
            {
                for (int index = 0; index < 16; index++)
                {
                    end_logo_index += 79;

                    Console.Write(new String(' ', 3));

                    Console.Write(sharp_gpt_logo[start_logo_index..(end_logo_index - (85 - Console.WindowWidth))]);

                    Console.Write(new String(' ', 3));

                    Console.Write("\r\n");

                    start_logo_index += 79;
                }
            }
            else
            {
                for (int index = 0; index < 16; index++)
                {
                    end_logo_index += 79;

                    Console.Write(new String(' ', half_remaining_width));

                    Console.Write(sharp_gpt_logo[start_logo_index..end_logo_index]);

                    Console.Write(new String(' ', half_remaining_width));

                    Console.Write("\r\n");

                    start_logo_index += 79;
                }
            }
        }


        private static void Print_Startup_Options()
        {
            //Console.Write(new String(''));
        }
    }
}
