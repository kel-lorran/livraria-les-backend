using System.Text.RegularExpressions;

namespace Shared.Utils
{
    public static class TextValidator
    {
        public static bool Validity(string? text = "", string pattern = @"\w+")
        {
            if (text == null)
                return false;
            Regex regex = new Regex(pattern);
            
            var result = regex.Matches(text);

            if(result.Count > 0)
                return true;
            return false;
        }
        public static bool Validity(string? text, string pattern, string replacePattern = @"\D")
        {
            text = Regex.Replace(text, replacePattern, "");
            if (text == null)
                return false;
            Regex regex = new Regex(pattern);
            
            var result = regex.Matches(text);

            if(result.Count > 0)
                return true;
            return false;
        }
    }
}