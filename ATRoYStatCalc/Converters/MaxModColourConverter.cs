using ATRoYStatCalc.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ATRoYStatCalc.Converters
{
    class MaxModColourConverter : IMultiValueConverter
    {

        //Skill skill = (Skill)value;
        //return skill.EquipmentBonus > (skill.Base + (skill.Base / 2)) ? Brushes.Red : Brushes.Black;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int baseValue = (int)values[0];
            int bonusValue = (int)values[1];
            
            return bonusValue > (baseValue + (baseValue / 2)) ? Brushes.Red : Brushes.Black;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
