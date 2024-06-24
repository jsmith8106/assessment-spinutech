namespace Assessments.Common
{
    // Extension method for converting numbers to words
    public static class NumberExtensions
    {
        private static readonly string[] Units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public static string ToWords(this int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + ToWords(Math.Abs(number));

            var words = "";

            if ((number / 1000) > 0)
            {
                words += ToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                if (number < 20)
                    words += Units[number];
                else
                {
                    words += Tens[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + Units[number % 10];
                }
            }

            return words.Trim();
        }
    }
}
