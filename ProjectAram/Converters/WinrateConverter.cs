using System;
using System.Globalization;
using System.Windows.Data;

namespace ProjectAram.Converters
{
    public class WinrateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                var resultOne = double.TryParse(values[0].ToString(), out var valueOne);
                var resultTwo = double.TryParse(values[1].ToString(), out var valueTwo);

                if (resultOne && resultTwo)
                {
                    var convert = Math.Round(100 / ((valueOne + valueTwo) / valueOne), 2);
                    return double.IsNaN(convert) ? 0 : convert;
                }
                else
                {
                    return Binding.DoNothing;
                }
            }

            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}