using System.Text.RegularExpressions;

namespace WakeApp.Web.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidIpAddress(this string value)
        {
            if (value == null)
            {
                return false;
            }
            var address = value.ToString();
            if (string.IsNullOrWhiteSpace(address))
            {
                return false;
            }
            return Regex.IsMatch(address, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        }

        public static bool IsValidMacAddress(this string value)
        {
            if (value == null)
            {
                return false;
            }
            var address = value.ToString()
                .Replace(":", "")
                .Replace("-", "");
            if (string.IsNullOrWhiteSpace(address))
            {
                return false;
            }
            return Regex.IsMatch(address, @"^[a-fA-F0-9]{12}$");
        }
    }
}
