using KeysHelper.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace KeysHelper
{
    internal static class SettingsDicHelper
    {
        // load toSim collection from Settings
        public static void LoadDic<TEnum1, TEnum2>(IDictionary<TEnum1, TEnum2> dic, string settingName)
            where TEnum1 : struct
            where TEnum2 : struct
        {
            if (string.IsNullOrWhiteSpace(settingName))
                throw new ArgumentNullException(nameof(settingName));
            if (dic == null)
                throw new ArgumentNullException(nameof(dic));

            dic.Clear();

            // can't save Dictionary<Keys, Keys>, so I use StringCollection

            StringCollection tmp = (StringCollection)Settings.Default[settingName];
            if (tmp != null && tmp.Count % 2 == 0)
            {
                for (int i = 0; i < tmp.Count - 1; i += 2)
                {
                    if (Enum.TryParse(tmp[i], out TEnum1 k1) &&
                        Enum.TryParse(tmp[i + 1], out TEnum2 k2))
                    {
                        dic.Add(k1, k2);
                    }
                }
            }
        }

        // save toSim collection to Settings, optionally writing all Settings to disk
        public static void SaveDic<TEnum1, TEnum2>(IDictionary<TEnum1, TEnum2> dic, string settingName, bool writeToDisk = false)
            where TEnum1 : struct
            where TEnum2 : struct
        {
            if (string.IsNullOrWhiteSpace(settingName))
                throw new ArgumentNullException(nameof(settingName));

            var tmp = new StringCollection();

            if (dic != null)
            {
                foreach (var key in dic.Keys)
                {
                    tmp.Add(key.ToString());
                    tmp.Add(dic[key].ToString());
                }
            }

            Settings.Default[settingName] = tmp;

            if (writeToDisk)
                SaveSettings();
        }

        // write Settings to disk
        public static void SaveSettings()
        {
            Settings.Default.Save();
        }
    }
}
