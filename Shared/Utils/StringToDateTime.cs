using System;

namespace Shared.Utils
{
    public class StringToDateTime
    {
        public static DateTime convert(string valueToConvert, string format = "dd/MM/yyyy")
        {
            return DateTime.ParseExact(valueToConvert, format, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}