using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Utility
{
    public static class DateTimeUtility
    {
        public static string ToShamsiDate(this DateTime? dt)
        {
            if (dt.HasValue)
            {
                return ToShamsiDate(dt.Value);
            }
            else
            {
                return default;
            }
        }

        public static string ToShamsiDate(this DateTime dt)
        {
            PersianCalendar persianCalendar = new();
            return $"{persianCalendar.GetYear(dt)}/{persianCalendar.GetMonth(dt).ToString("00")}/{persianCalendar.GetDayOfMonth(dt).ToString("00")}";
        }

        public static string ToShamsiDateTime(this DateTime? dt)
        {
            if (dt.HasValue)
            {
                return ToShamsiDateTime(dt.Value);
            }
            else
            {
                return default;
            }
        }

        public static string ToShamsiDateTime(this DateTime dt)
        {
            return $"{dt.ToShamsiDate()} ساعت {dt:HH:mm}";
        }

        public static string ToLongShamsiDate(this DateTime dt)
        {
            PersianCalendar persianCalendar = new();

            var intYear = persianCalendar.GetYear(dt);
            var intMonth = persianCalendar.GetMonth(dt);
            var intDayOfMonth = persianCalendar.GetDayOfMonth(dt);
            var strMonthName = intMonth switch
            {
                1 => "فروردین",
                2 => "اردیبهشت",
                3 => "خرداد",
                4 => "تیر",
                5 => "مرداد",
                6 => "شهریور",
                7 => "مهر",
                8 => "آبان",
                9 => "آذر",
                10 => "دی",
                11 => "بهمن",
                12 => "اسفند",
                _ => "",
            };

            return $"{intDayOfMonth} {strMonthName} {intYear}";
        }

        public static DateTime ToDateTime(this string input)
        {
            if (input.Length != 10 || input.Split('/').Length != 3)
            {
                return default;
            }

            var splittedInput = input.Split('/');
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(Convert.ToInt32(splittedInput[0]), Convert.ToInt32(splittedInput[1]), Convert.ToInt32(splittedInput[2]), pc);
        }

        public static string GetDay(this DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Saturday => "شنبه",
                DayOfWeek.Sunday => "یک‌شنبه",
                DayOfWeek.Monday => "دوشنبه",
                DayOfWeek.Tuesday => "سه‌شنبه",
                DayOfWeek.Wednesday => "چهارشنبه",
                DayOfWeek.Thursday => "پنج‌شنبه",
                DayOfWeek.Friday => "جمعه",
                _ => null,
            };
        }
    }
}
