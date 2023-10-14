using Eva_5._0;

namespace SharpGPT
{
    class Program
    {
        private static object dummy_thread_synchronisation_object = new object();
        private static int current_console_width = 0;
        private static int current_console_height = 0;

        public static Screens current_screen = Screens.Startup_Screen;
        public static int cursor_location = 0;

        public enum Screens
        {
            Startup_Screen,
            Settings_Screen,
            API_Key_Setup_Screen,
            Chat_Screen
        }

        private static void Main()
        {
            GUI.Initiatilise_Default_Console_Colours();

            Console.TreatControlCAsInput = true;
            Console.CursorVisible = false;
            Task.Run(Operation).Wait();
        }

        private static void Operation()
        {
            System.Timers.Timer screen_content_adjustment_timer = new System.Timers.Timer();
            screen_content_adjustment_timer.Elapsed += Size_Detection;
            screen_content_adjustment_timer.Interval = 1;
            screen_content_adjustment_timer.Start();


            while(true)
            {
                ConsoleKeyInfo cki = Console.ReadKey();

                switch(cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(cursor_location > 0)
                        {
                            cursor_location--;
                            Operational_Controller.Operation_Selector.Operational_Controller_Method(current_screen);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor_location < GUI.Get_Current_Screen_Collection_Size(Screens.Startup_Screen) - 1)
                        {
                            cursor_location++;
                            Operational_Controller.Operation_Selector.Operational_Controller_Method(current_screen);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        break;
                    case ConsoleKey.RightArrow:
                        break;
                    case ConsoleKey.Enter:
                        Option_Selector();
                        break;
                    default:
                        Operational_Controller.Operation_Selector.Operational_Controller_Method(current_screen);
                        break;
                }
            }
        }


        private static void Size_Detection(object? sender, System.Timers.ElapsedEventArgs e)
        {
            // MAKE EACH TIMER THREAD LOCK A STATICALLY ALLOCATED OBJECT.
            // THIS WILL ENSURE THREAD SYNCHRONISATION. WHEN EACH THREAD
            // LOCKS A COMMON OBJECT AND THUS, EACH THREAD WILL WAIT
            // FOR THE OBJECT TO BE FREED BY THE THREAD THAT CURRENTLY
            // LOCKED THE OBJECT.
            //
            lock(dummy_thread_synchronisation_object)
            {
                if (current_console_height != Console.WindowHeight)
                {
                    Operational_Controller.Operation_Selector.Operational_Controller_Method(current_screen);
                    current_console_height = Console.WindowHeight;
                    current_console_width = Console.WindowWidth;
                }
                else if (current_console_width != Console.WindowWidth)
                {
                    Operational_Controller.Operation_Selector.Operational_Controller_Method(current_screen);
                    current_console_height = Console.WindowHeight;
                    current_console_width = Console.WindowWidth;
                }
            }

            Thread.CurrentThread.Join();
        }


        private static void Option_Selector()
        {

            switch(current_screen)
            {
                case Screens.Startup_Screen:
                    switch (GUI.Get_Current_Option(Screens.Startup_Screen))
                    {
                        case "Start conversation":
                            break;
                        case "Load conversation":
                            break;
                        case "Settings":
                            cursor_location = 0;
                            current_screen = Screens.Settings_Screen;
                            Operational_Controller.Operation_Selector.Operational_Controller_Method(current_screen);
                            break;
                        case "Exit":
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                    }
                    break;
            }
        }


        private static void Empty_STDIN_Stream()
        {

        }
    }
}
