namespace SharpGPT
{
    class Program
    {
        private static void Main()
        {
            Init();
        }





        private static async void Init()
        {
            System.Diagnostics.Debug.WriteLine((await Settings_Controller.Settings_Operation(Settings_Controller.Operations.Get_API_Key, String.Empty)));
            Console.WriteLine("OK");
            Console.ReadLine();
        }
    }
}
