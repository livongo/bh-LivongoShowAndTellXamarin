using System;
using System.Collections.Generic;

namespace LivongoShowAndTell2.Network
{
    public static class ConfigUtil
    {
        public static List<ConfigDisplayRow> ConvertToDisplay(Config c)
        {
            var list = new List<ConfigDisplayRow>();

            foreach (var key in c.clients.Keys)
            {
                list.Add(new ConfigDisplayRow(key, RowType.TITLE));
                var item = c.clients[key];

                var formatA = "Analytics Code: {0}";
                formatA = string.Format(formatA, item.analyticsTrackingCode ?? "No Data");
                list.Add(new ConfigDisplayRow(formatA, RowType.DETAIL));

                var formatB = "Current Version: {0}";
                formatB = string.Format(formatB, item.currentVersion ?? "No Data");
                list.Add(new ConfigDisplayRow(formatB, RowType.DETAIL));

                var formatC = "Minimum Version: {0}";
                formatC = string.Format(formatC, item.minimumVersion ?? "No Data");
                list.Add(new ConfigDisplayRow(formatC, RowType.DETAIL));
            }

            return list;
        }
    }

    public enum RowType { TITLE, DETAIL }

    public class ConfigDisplayRow
    {
        public RowType RType { get; private set; }
        public string Name { get; private set; }

        public ConfigDisplayRow(string name, RowType type)
        {
            this.Name = name;
            this.RType = type;
        }
    }

    public interface IBindable
    {
        void Bind(string s);
    }
}
