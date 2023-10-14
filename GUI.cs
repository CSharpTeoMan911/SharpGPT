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


        private static List<string> startup_screen_options = new List<string>() {"Start conversation", "Load conversation", "Settings", "Exit"};

        private static List<string> settings_screen_options = new List<string>() { "Background color", "Foreground color", "API Key" };

        private static ConsoleColor application_foreground_color = ConsoleColor.Green;
        private static ConsoleColor application_background_color = ConsoleColor.Black;

        private static ConsoleColor default_backgound_color = Console.BackgroundColor;
        private static ConsoleColor default_foreground_color = Console.ForegroundColor;


        public static void Initiatilise_Default_Console_Colours()
        {
            default_backgound_color = Console.BackgroundColor;
            default_foreground_color = Console.ForegroundColor;
        }


        public static int Get_Current_Screen_Collection_Size(Program.Screens screen)
        {
            int current_collection_size = 0;

            switch(screen)
            {
                case Program.Screens.Startup_Screen:
                    current_collection_size = startup_screen_options.Count;
                    break;
            }

            return current_collection_size;
        }


        public static string Get_Current_Option(Program.Screens screen)
        {
            string current_option = String.Empty;

            switch (screen)
            {
                case Program.Screens.Startup_Screen:
                    current_option = startup_screen_options.ElementAt(Program.cursor_location);
                    break;
            }

            return current_option;
        }



        public static void Startup_Screen()
        {

            Console.ForegroundColor = application_foreground_color;
            Console.BackgroundColor = application_background_color;
            Console.Write(new String(' ', Console.WindowWidth * 2));

            Print_Logo();

            Console.Write(new String(' ', Console.WindowWidth * 2));

            Console.Write(new String(' ', Console.WindowWidth * 2));

            Print_Startup_Options();

            int current_cursor_location = Console.CursorTop;

            while(current_cursor_location < Console.WindowHeight - 1)
            {
                Console.Write(new String(' ', Console.WindowWidth));
                current_cursor_location++;
            }

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
            ConsoleColor default_backgound_color = Console.BackgroundColor;
            ConsoleColor default_foreground_color = Console.ForegroundColor;

            int small_width = Console.WindowWidth / 4;
            bool cursor = false;

            White_Space_Initiator(small_width);

            White_Space_Delimiter(small_width);
            White_Space_Delimiter(small_width);


            for (int index = 0; index < startup_screen_options.Count; index++)
            {
                int large_width = Console.WindowWidth - (small_width * 2);
                int remaining_width_value = 0;
                int calculated_remaining_width_value = 0;

                Console.BackgroundColor = application_background_color;
                Console.ForegroundColor = application_foreground_color;

                if (index == Program.cursor_location)
                {
                    cursor = true;
                }
                else
                {
                    cursor = false;
                }

                Console.Write(new String(' ', small_width));
                
                switch (cursor)
                {
                    case true:
                        Delimiter();

                        Console.Write(new String(' ', 2));
                        large_width -= 3;

                        Console.BackgroundColor = application_foreground_color;
                        Console.ForegroundColor = application_background_color;

                        Console.Write(" > ");
                        large_width -= 3;

                        remaining_width_value = large_width - 6 - startup_screen_options.ElementAt(index).Length;

                        switch (remaining_width_value >= 0)
                        {
                            case true:
                                Console.Write(startup_screen_options.ElementAt(index)[0..]);
                                large_width -= startup_screen_options.ElementAt(index).Length;
                                break;
                            case false:
                                calculated_remaining_width_value = startup_screen_options.ElementAt(index).Length - (remaining_width_value * -1);
                                
                                if(calculated_remaining_width_value >= 0)
                                {
                                    Console.Write(startup_screen_options.ElementAt(index)[0..calculated_remaining_width_value]);
                                }
                                large_width -= calculated_remaining_width_value;
                                break;
                        }

                        if (large_width - 3 >= 0)
                        {
                            Console.Write(new String(' ', large_width - 3));
                        }

                        Console.BackgroundColor = application_background_color;
                        Console.ForegroundColor = application_foreground_color;

                        Console.Write(new String(' ', 2));

                        Delimiter();
                        break;
                    case false:
                        Delimiter();

                        Console.Write(new String(' ', 2));
                        large_width -= 3;

                        remaining_width_value = large_width - 3 - startup_screen_options.ElementAt(index).Length;

                        switch(remaining_width_value >= 0)
                        {
                            case true:
                                Console.Write(startup_screen_options.ElementAt(index)[0..]);
                                large_width -= startup_screen_options.ElementAt(index).Length;
                                break;
                            case false:
                                calculated_remaining_width_value = startup_screen_options.ElementAt(index).Length - (remaining_width_value * -1);

                                if (calculated_remaining_width_value >= 0)
                                {
                                    Console.Write(startup_screen_options.ElementAt(index)[0..calculated_remaining_width_value]);
                                }
                                large_width -= calculated_remaining_width_value; 
                                break;
                        }

                        if (large_width - 1  >= 0)
                        {
                            Console.Write(new String(' ', large_width - 1));
                        }

                        Console.BackgroundColor = application_background_color;
                        Console.ForegroundColor = application_foreground_color;

                        Delimiter();
                        break;
                }

                Console.Write(new String(' ', small_width));

                Console.BackgroundColor = ConsoleColor.Black;

                White_Space_Delimiter(small_width);
                White_Space_Delimiter(small_width);
            }

            White_Space_Terminator(small_width);
        }

        private static void White_Space_Initiator(int small_width)
        {
            Console.Write(new String(' ', small_width));
            Console.BackgroundColor = application_foreground_color;
            Console.Write(new String(' ', (Console.WindowWidth - (small_width * 2))));
            Console.BackgroundColor = default_backgound_color;
            Console.Write(new String(' ', small_width));
        }

        private static void White_Space_Delimiter(int small_width)
        {
            Console.Write(new String(' ', small_width));
            Delimiter();
            Console.Write(new String(' ', (Console.WindowWidth - (small_width * 2)) - 2));
            Delimiter();
            Console.Write(new String(' ', small_width));
        }

        private static void White_Space_Terminator(int small_width)
        {
            Console.Write(new String(' ', small_width));
            Delimiter();
            Console.BackgroundColor = application_foreground_color;
            Console.Write(new String(' ', (Console.WindowWidth - (small_width * 2)) - 2));
            Console.BackgroundColor = default_backgound_color;
            Delimiter();
            Console.Write(new String(' ', small_width));
        }

        private static void Delimiter()
        {
            Console.BackgroundColor = application_foreground_color;
            Console.Write(' ');
            Console.BackgroundColor = default_backgound_color;
        }



        public static void Settings_Screen()
        {
            Console.Write(new String(' ', Console.WindowWidth * 18));

            int small_width = Console.WindowWidth / 4;
            bool cursor = false;

            White_Space_Initiator(small_width);
        }

        public static void Settings_Screen_Title()
        {
            int small_width = Console.WindowWidth / 4;
            bool cursor = false;

            Console.Write(new String(' ', small_width));
            Console.Write('|');
            Console.Write(new String('_', (Console.WindowWidth - (small_width * 2)) - 2));
            Console.Write('|');
            Console.Write(new String(' ', small_width));
        }
    }
}
