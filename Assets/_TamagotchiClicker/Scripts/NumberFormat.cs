namespace TamagotchiClicker
{
    public class NumberFormat
    {
        private const double Thousand = 1000;
        private const double Million = 1000000;
        private const double Billion = 1000000000;
        private const double Trillion = 1000000000000;

        public static string GetFormattedString(ulong number)
        {
            if (number >= Trillion)
                return (number / Trillion).ToString("#.###############") + "T";

            if (number >= Billion)
                return (number / Billion).ToString("#.############") + "B";

            if (number >= Million)
                return (number / Million).ToString("#.######") + "M";

            if (number >= Thousand)
                return (number / Thousand).ToString("#.###") + "K";
            
            return number.ToString();
        }
    }
}
