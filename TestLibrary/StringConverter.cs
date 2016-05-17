using System;

namespace TestLibrary
{
    /// <summary>
    /// Performs conversions from strings to various types without throwing exceptions
    /// as needed by the parser.
    /// </summary>
    public class StringConverter : IStringConverter
    {
        /// <summary>
        /// Convert a string to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="text">Contains the text that should be parsed to date.</param>
        /// <returns>A <see cref="DateTime"/> with the value converted from the parameter, or
        /// returns <see cref="DateTime.MinValue"/> if the text is an invalid date.</returns>
        public DateTime ConvertDate(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return DateTime.MinValue;
            }

            DateTime date;

            return DateTime.TryParse(text, out date) ? date : DateTime.MinValue;
        }

        /// <summary>
        /// Convert a string to <see cref="Decimal"/>.
        /// </summary>
        /// <param name="text">Contains the text that should be parsed to decimal.</param>
        /// <returns>A <see cref="Decimal"/> with the value converted from the parameter, or
        /// returns <see cref="Decmal.MinValue"/> if the text is an invalid decimal.</returns>
        public Decimal ConvertSalary(string entry)
        {
            if (string.IsNullOrWhiteSpace(entry))
            {
                return Decimal.MinValue;
            }

            Decimal salary;

            return Decimal.TryParse(entry, out salary) ? salary : Decimal.MinValue;
        }
    }
}
