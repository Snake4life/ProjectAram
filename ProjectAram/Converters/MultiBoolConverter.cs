using System;
using System.Globalization;
using System.Windows.Data;

namespace ProjectAram.Converters
{
    public class MultiBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var i in values)
            {
                if (!(i is bool) || (bool)i == false)
                {
                    return false;
                }
            }

            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var iRes = new object[targetTypes.Length];
            for (var i = 0; i < targetTypes.Length; i++)
            {
                iRes[i] = value;
            }

            return iRes;
        }

    }
}