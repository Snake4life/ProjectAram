using System;
using System.Globalization;
using System.Windows.Data;

namespace ProjectAram.Converters
{
    public class KdaConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 3)
            {
                var resultOne = double.TryParse(values[0].ToString(), out var kills);
                var resultTwo = double.TryParse(values[1].ToString(), out var deaths);
                var resultThree = double.TryParse(values[2].ToString(), out var assists);

                if (resultOne && resultTwo && resultThree)
                {
                    return Math.Round((kills + assists) / Math.Max(deaths, 1), 2);
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