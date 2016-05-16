using System;

namespace TestLibrary
{
    public class Employee
    {

        // Constuctor to assign Guid to each instance of the class
        public Employee()
        {
            this.Id = Guid.NewGuid();
        }

        // Attributes for the Employee class
        public Guid Id { get; set; }
        public String FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public Decimal Salary { get; set; }
        public DateTime DateHired { get; set; }
        
        // Boolean method and string to test and print whether the data is valid
        public String PrintIfValid { get; set; }

        // Boolean method to flag records as invalid if the name is blank, salary is not greater than 0, or the dates are invalid
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.FullName) &&
                       this.Salary != Decimal.MinValue && this.Salary > 0 &&
                       this.Birthdate != DateTime.MinValue &&
                       this.DateHired != DateTime.MinValue;
            }

        }

    }
}
