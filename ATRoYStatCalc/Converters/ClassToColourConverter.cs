using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ATRoYStatCalc.Converters
{
    class ClassToColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((string)value)
            {
                case "Mage":
                    return Brushes.DodgerBlue;

                case "Warrior":
                    return Brushes.DarkRed;

                case "Seyan'du":
                    return Brushes.DarkSlateBlue;

                case "Rogue":
                    return Brushes.SlateGray;

                default:
                    return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
