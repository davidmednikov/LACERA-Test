using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestLibrary;

namespace TestWebApp.Models
{
    /// <summary>
    /// Contains all <see cref="Home"/> View data to be represented in the model.
    /// </summary>
    public class HomeViewModels
    {
        /// <summary>
        /// Gets or sets the <see cref="Title"/> of the Model View.
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Message"/> of the Model View.
        /// </summary>
        public String Message { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Exception"/> of the Model View.
        /// </summary>
        public String Exception { get; set; }
        /// <summary>
        /// Gets or sets a boolean that states whether or not the file has been uploaded.
        /// </summary>
        public bool Uploaded { get; set; }
        /// <summary>
        /// Gets or sets a list of Employees in the database.
        /// </summary>
        public List<EmployeesDB> EmployeesDBs { get; set; }
    }
}