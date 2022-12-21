using System;
using System.Collections.Generic;
using System.Text;

namespace ApiExtensionChrome.Utilities.Exceptions
{
    public class ApiChromeExtensionException:Exception
    {
        public ApiChromeExtensionException()
        {

        }
        public ApiChromeExtensionException(string message):base(message)
        {

        }
    }
}
