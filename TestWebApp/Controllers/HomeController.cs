using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TestLibrary;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {

        // Action Method for Index Page
        public ActionResult Index()
        {
            
            // Create new instance of HomeViewModel
            var model = new HomeViewModels();


            // TempData["FilePath"] is a TempData string that contains the location of the CSV on the web server.
            // The string is created when the CSV is uploaded. The following code only runs when TempData["FilePath"] is not null.
            // If TempData["FilePath"] is null then the program executes the code in the "Else" loop, which displays the form to upload the CSV.

            if (TempData["FilePath"] != null)
            {
                model.Title = "Results";
                model.Message = "Your results page.";

                // This section of code only runs when the CSV has been uploaded. This particular line changes model.Uploaded to True so that the
                // Index.cshtml page (which has an If loop with model.Uploaded as the argument) displays the Results once the CSV has been uploaded and parsed.
                model.Uploaded = true;

                // Try to parse the data, return an exception if there is an error
                try
                {
                    // Initiate parser object from Parser class
                    StringConverter stringConverter = new TestLibrary.StringConverter();
                    FileValidator fileValidator = new TestLibrary.FileValidator();
                    EmployeeGenerator employeeGenerator = new TestLibrary.EmployeeGenerator(stringConverter);
                    LineParser lineParser = new TestLibrary.LineParser(stringConverter, employeeGenerator);
                    Parser parser = new TestLibrary.Parser(fileValidator, lineParser);


                    // Take TempData["FilePath"] from HttpPost method and assign it to String called path, to be used as an argument for Parse method
                    String path = TempData["FilePath"].ToString();

                    // Run Parse method using file path string created above
                    model.Employees = parser.Parse(path);

                    return View(model);
                }
                // If parsing causes an error, return model with Exception message
                catch (Exception ex)
                {
                    model.Message = "An errror was encountered while parsing.";
                    model.Exception = ex.Message;
                    return View(model);
                }
             
            }

            // The following code only runs when TempData["FilePath"] is null, which happens if a file has not been uploaded yet.
            else
            {
                model.Title = "Upload";
                model.Message = "Parse your CSV file here.";
                return View(model);
            }
            
        }

        // Action method for About page
        public ActionResult About()
        {
            var model = new HomeViewModels();
            model.Title = "About";
            model.Message = "This WebApp parses a CSV and returns the data in table form.";

            return View(model);
        }

        // Action method for Contact page
        public ActionResult Contact()
        {
            var model = new HomeViewModels();
            model.Title = "Contact";
            model.Message = "Contact me at the following:";

            return View(model);
        }

        // HttpPost Method for Index page. This code only runs after the form asking for file upload is submitted.
        // Uploaded file takes the form of argument CSV.
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase CSV)
        {
            // Execute the following code if CSV is not null and ContentLength is greater than 0
            // This action method should only run after an actual CSV has been uploaded, so the two parameters should be met
            if (CSV != null && CSV.ContentLength > 0)
            {
                // Create string FileName from name of CSV file
                var FileName = Path.GetFileName(CSV.FileName);

                // Saves CSV to WebApp server at ~/Content/FileName/
                CSV.SaveAs(Server.MapPath("~/Content/") + CSV.FileName);

                // Create string path from CSV's location on WebServer so that Parse method knows where to look
                string path = Path.Combine(Server.MapPath("~/Content/"), FileName);

                // Saves path string to TempData so that a different request can access it
                // Also allows If loop in Index action to determine whether or not TempData["FilePath"] is null
                TempData["FilePath"] = path;

                // Redirect back to Index action, this time with data in TempData["FilePath"] so that the If loop executes
                return RedirectToAction("Index", "Home");

            }

            return View();
        }
    }
}