using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;

namespace RCmechanics
{
    public class StringFormatConverter : IValueConverter
    {
        rcmsettings Settings = new rcmsettings();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        {
            if (Settings.ListPickerSetting == 1)
            {
                String.Format("{0:0.000}",value);
                return (string)value + " mm";
            } 
            if (Settings.ListPickerSetting == 2)
            {
                String.Format("{0:0.0}",value);
                return (string)value + " inch";
            }
                return value.ToString();

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        {
            //throw new NotImplementedException();
            return value;
        }
    }
}

