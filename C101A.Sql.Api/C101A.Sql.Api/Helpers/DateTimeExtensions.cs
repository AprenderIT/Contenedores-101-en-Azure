
using System;

namespace C101A.Sql.Api.Helpers
{
    public static class DateTimeExtensions
    {
        //https://stackoverflow.com/questions/11/calculate-relative-time-in-c-sharp?page=1&tab=votes#tab-top
        public static string GetRelativeTime(this DateTime dateTime)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - dateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "Hace un segundo" : "Hace " + ts.Seconds + " segundos";

            if (delta < 2 * MINUTE)
                return "Hace un minuto";

            if (delta < 45 * MINUTE)
                return "Hace " + ts.Minutes + " minutos";

            if (delta < 90 * MINUTE)
                return "Hace una hora";

            if (delta < 24 * HOUR)
                return "Hace " + ts.Hours + " horas";

            if (delta < 48 * HOUR)
                return "ayer";

            if (delta < 30 * DAY)
                return "Hace " + ts.Days + " días";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "Hace un mes" : "Hace " + months + " meses";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "Hace un año" : "Hace " + years + " años";
            }
        }
    }
}
