using System;

namespace TestLibrary
{
    /// <summary>
    /// Represents employee information retrieved from various sources including parsed files.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Constuctor assigns <see cref="Guid"/> to each new instance of the class.
        /// </summary>
        public Employee()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets a unique identifier for the employee.
        /// </summary>
        public Guid Id { get; set; }

        public String FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public Decimal Salary { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime DateTerminated { get; set; }

        /// <summary>
        /// Gets or sets a string to be printed that tells the user whether or not the data is valid.
        /// </summary>
        public String PrintIfValid { get; set; }

        /// <summary>
        /// Boolean method that flags records as invalid if the name is blank, salary is not greater than 0, or the dates are invalid.
        /// </summary>
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
