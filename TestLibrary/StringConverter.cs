using System;

namespace TestLibrary
{
    public class StringConverter
    {
        // Method to convert date in string form to DateTime type
        public DateTime ConvertDate(string entry)
        {
            // Return MinValue of DateTime if field is null or blank
            if (string.IsNullOrWhiteSpace(entry))
            {
                return DateTime.MinValue;
            }

            // Create variable date of type DateTime
            DateTime date;

            // If string can be converted to DateTime, return date. if string cannot be converted to DateTime, return MinValue
            if (DateTime.TryParse(entry, out date))
            {
                return date;
            }
            else
            {
                return DateTime.MinValue;
            }

        }

        // Method to convert salary in string form to Decimal type
        public Decimal ConvertSalary(string entry)
        {
            // Return MinValue of Decimal if field is null or blank
            if (string.IsNullOrWhiteSpace(entry))
            {
                return Decimal.MinValue;
            }

            // Create variable salary of type Decimal
            Decimal salary;

            // If string can be converted to Decimal, return salary. if string cannot be converted to Decimal, return MinValue
            if (Decimal.TryParse(entry, out salary))
            {
                return salary;
            }
            else
            {
                return Decimal.MinValue;
            }
        }
    }
}
