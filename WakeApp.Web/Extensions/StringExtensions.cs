using System.Text.RegularExpressions;

namespace WakeApp.Web.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidIpAddress(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? false : Regex.IsMatch(value, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        }

        public static bool IsValidMacAddress(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? false : Regex.IsMatch(value, @"^([a-fA-F0-9]{2}[:-]){5}[a-fA-F0-9]{2}$");
        }
    }
}
