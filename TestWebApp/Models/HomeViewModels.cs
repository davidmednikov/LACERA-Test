using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestLibrary;

namespace TestWebApp.Models
{
    // This model will be used for all Actions under the Home Controller
    public class HomeViewModels
    {
        // Model element with page title
        public String Title { get; set; }

        // Model element with message to display to user
        public String Message { get; set; }

        // Model element for containing exception
        public String Exception { get; set; }

        // Model element that contains boolean, changes from false to true after uploading CSV
        public bool Uploaded { get; set; }

        // Model element that contains instance of Employee class
        public List<Employee> Employee { get; set; }
    }
}