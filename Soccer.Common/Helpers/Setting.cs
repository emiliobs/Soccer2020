using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Common.Helpers
{
    public static class Setting
    {
        private const string _tournament = "tournament";
        private static readonly string _stringDefault = string.Empty;

        private static ISettings APPSettings => CrossSettings.Current;

        public static string Tournament 
        {
            get => APPSettings.GetValueOrDefault(_tournament, _stringDefault);
            set => APPSettings.AddOrUpdateValue(_tournament, value);
        }
    }
}
