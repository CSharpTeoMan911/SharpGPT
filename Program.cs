using Eva_5._0;

namespace SharpGPT
{
    class Program
    {
        private static object dummy_thread_synchronisation_object = new object();

        private static int current_console_width = 0;
        private static int current_console_height = 0;

        public static Screens current_screen = Screens.Startup_Screen;
        public enum Screens
        {
            Startup_Screen,
            Settings_Screen,
            API_Key_Setup_Screen,
            Chat_Screen
        }

        private static void Main()
        {
            Operation();
            Console.ReadLine();
        }

        private static void Operation()
        {
            System.Timers.Timer screen_content_adjustment_timer = new System.Timers.Timer();
            screen_content_adjustment_timer.Elapsed += Size_Detection;
            screen_content_adjustment_timer.Interval = 1;
            screen_content_adjustment_timer.Start();


            while(Console.KeyAvailable == true)
            {
                ConsoleKeyInfo cki = Console.ReadKey();

                switch(cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.DownArrow:
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


        private static void Empty_STDIN_Stream()
        {

        }
    }
}
