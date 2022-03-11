using System.Globalization;

namespace NomorIdaman.Application.Common.Formatters {
    public class NumberFormatters {
        public class Currency {
            public static string Format(decimal number) {
                var numberFormat = new CultureInfo(CurrentCultureInfo.Id).NumberFormat;
                numberFormat.CurrencyPositivePattern = 2;
                return number.ToString("C0", numberFormat);
            }
        }
    }
}
