using System.Text;

namespace SharpGPT
{
    class Settings
    {
        private static string settings_file_name = "settings.json";

        private sealed class Application_Settings
        {
            public string API_KEY;
        }


        protected static async void Set_ChatGPT_Api_Key(string api_key)
        {
            Application_Settings settings = new Application_Settings();
            settings.API_KEY = api_key;

            byte[] serialised_settings = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(settings));

            System.IO.FileStream settings_file_stream = System.IO.File.Create(settings_file_name);
            try
            {
                await settings_file_stream.WriteAsync(serialised_settings, 0 , serialised_settings.Length, CancellationToken.None);
                await settings_file_stream.FlushAsync();
            }
            catch
            {

            }
            finally
            {
                if(settings_file_stream != null)
                {
                    settings_file_stream.Close();
                    await settings_file_stream.DisposeAsync();
                }
            }
        }

        protected static async Task<string> Get_ChatGPT_Api_Key()
        {
            string api_key = String.Empty;

            System.IO.FileStream settings_file_stream = System.IO.File.OpenRead(settings_file_name);
            try
            {
                byte[] file_buffer = new byte[settings_file_stream.Length];
                await settings_file_stream.ReadAsync(file_buffer, 0, file_buffer.Length);

                Application_Settings? settings = Newtonsoft.Json.JsonConvert.DeserializeObject<Application_Settings>(Encoding.UTF8.GetString(file_buffer));

                if(settings != null)
                {
                    api_key = settings.API_KEY;
                }
            }
            catch
            {

            }
            finally
            {
                if (settings_file_stream != null)
                {
                    settings_file_stream.Close();
                    await settings_file_stream.DisposeAsync();
                }
            }


            return api_key;
        }
    }
}