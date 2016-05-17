using System;

namespace TestLibrary
{
    public interface IStringConverter
    {
        /// <summary>
        /// Convert a string to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="text">Contains the text that should be parsed to date.</param>
        /// <returns>A <see cref="DateTime"/> with the value converted from the parameter, or
        /// returns <see cref="DateTime.MinValue"/> if the text is an invalid date.</returns>
        DateTime ConvertDate(string text);

        /// <summary>
        /// Convert a string to <see cref="Decimal"/>.
        /// </summary>
        /// <param name="text">Contains the text that should be parsed to decimal.</param>
        /// <returns>A <see cref="Decimal"/> with the value converted from the parameter, or
        /// returns <see cref="Decimal.MinValue"/> if the text is an invalid decimal.</returns>
        Decimal ConvertSalary(string entry);
    }
}
