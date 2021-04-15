using System;

namespace Shared.Utils
{
    public class StringToDateTime
    {
        public static DateTime Convert(string valueToConvert, string format = "dd/MM/yyyy")
        {
            return DateTime.ParseExact(valueToConvert, format, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}