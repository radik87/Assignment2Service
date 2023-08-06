using System.Text.RegularExpressions;

namespace Service.Model
{
    public class RegexModel
    {
        public static readonly Regex SixCharLenght = new Regex(@"^[A-Za-z]{6}$");

        public static readonly Regex EndComma = new Regex(@"^[A-Za-z]{6}\,$");

        public static readonly Regex EndPeriod = new Regex(@"^[A-Za-z]{6}\.$");

        public static readonly Regex EndExlemationMark = new Regex(@"^[A-Za-z]{6}!$");

        public static readonly Regex EndQuerryMark = new Regex(@"^[A-Za-z]{6}\?$");

        public static readonly Regex EndColon = new Regex(@"^[A-Za-z]{6}:$");

        public static readonly Regex EndSemiColon = new Regex(@"^[A-Za-z]{6};$");
    }
}
