using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGPT
{
    internal class Settings_Controller:Settings
    {
        public enum Operations
        {
            Set_API_Key,
            Get_API_Key
        }

        public static async Task<string?> Settings_Operation(Operations operation, string parameter)
        {
            string? return_value = null;

            switch(operation)
            {
                case Operations.Set_API_Key:
                    Set_ChatGPT_Api_Key(parameter);
                    break;
                case Operations.Get_API_Key:
                    return_value = await Get_ChatGPT_Api_Key();
                    break;
            }

            return return_value;
        }
    }
}
