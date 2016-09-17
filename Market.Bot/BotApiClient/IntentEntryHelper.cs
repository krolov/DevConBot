using Market.Bot.BotApiClient.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Market.Bot.BotApiClient
{
    public static class IntentEntryHelper
    {

        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return string.Empty;
        }

        public static DateRange GetDateRange(string entry)
        {
            entry = entry.Replace(" ", "").Trim().ToLower();
            switch (entry)
            {
                case "today":
                    return DateRange.today;

                case "week":
                    return DateRange.week;
                case "year":
                    return DateRange.year;
                case "yesterday":
                    return DateRange.yesterday;
                case "month":
                    return DateRange.month;
                default:
                    return DateRange.today;
            }
        }

        public static List<Sections> GetSection(string entry)
        {
            entry = entry.Replace(" ", "").Trim().ToLower();
            switch (entry)
            {
                case "moscow":
                    return new List<Sections>() { Sections.Default };
                case "moscowregion":
                    return new List<Sections>() { Sections.EasuzMoscowRegion };
                case "volgograd":
                    return new List<Sections>() { Sections.Volgograd };
                case "volgogradregion":
                    return new List<Sections>() { Sections.VolgogradRegion };
                default:
                    return new List<Sections>();
            }
        }
    }
}