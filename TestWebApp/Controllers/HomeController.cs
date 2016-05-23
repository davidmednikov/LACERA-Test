using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestLibrary;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        
        /// <summary>
        /// Displays index page. Using TempData as a parameter, View shows uploader interface if file 
        /// has not been uploaded and shows results table if file has been uploaded.
        /// </summary>
        /// <param name="TempData["FilePath"]">Contains location of uploaded file on server.</param>
        /// <returns>View with data in model.</returns>
        public ActionResult Index()
        {
            var model = new HomeViewModels();

            /// <summary>
            /// Displays results view if TempData["FilePath"] is not null.
            /// </summary>
            /// <param name ="TempData["FilePath"]">Contains path of uploaded file.</param>
            if (TempData["FilePath"] != null)
            {
                model.Title = "Results";
                model.Message = "Your results page.";
                model.Uploaded = true;

                try
                {
                    // Initialize dependencies
                    StringConverter stringConverter = new TestLibrary.StringConverter();
                    FileValidator fileValidator = new TestLibrary.FileValidator();
                    EmployeeGenerator employeeGenerator = new TestLibrary.EmployeeGenerator(stringConverter);
                    LineParser lineParser = new TestLibrary.LineParser(stringConverter, employeeGenerator);
                    Parser parser = new TestLibrary.Parser(fileValidator, lineParser);

                    String path = TempData["FilePath"].ToString();

                    using (var db = new EmployeeModelContainer())
                    {
                        ClearTable(db);
                        var Employees = parser.Parse(path);
                        PopulateTable(db, Employees);
                        model.EmployeesDBs = db.EmployeesDBs.ToList();
                    }

                    return View(model);
                }
                catch (Exception ex)
                {
                    model.Message = "An errror was encountered while parsing.";
                    model.Exception = ex.Message;
                    return View(model);
                }
             
            }

            /// <summary>
            /// Displays upload view if TempData["FilePath"] is null, meaning file has not yet been uploaded.
            /// </summary>
            else
            {
                model.Title = "Upload";
                model.Message = "Parse your CSV file here.";
                return View(model);
            }
            
        }

        /// <summary>
        /// Displays <see cref="About"/>View.
        /// </summary>
        /// <returns><see cref="About"/>View with model.</returns>
        public ActionResult About()
        {
            var model = new HomeViewModels();
            model.Title = "About";
            model.Message = "This WebApp parses a CSV and returns the data in table form.";

            return View(model);
        }

        /// <summary>
        /// Displays <see cref="Contact"/>View.
        /// </summary>
        /// <returns><see cref="Contact"/>View with model.</returns>
        public ActionResult Contact()
        {
            var model = new HomeViewModels();
            model.Title = "Contact";
            model.Message = "Contact me at the following:";

            return View(model);
        }

        /// <summary>
        /// After file is uploaded, saves file to server and saves file path in <see cref="TempData["FilePath"]"/>
        /// so that <see cref="Index"/> view can display results table.
        /// </summary>
        /// <param name="CSV">Uploaded CSV, provided by post method from form submission.</param>
        /// <returns>Redirets to <see cref="Index"/>View, this time displaying results because <see cref="TempDataDictionary["FilePath"]"/>is not null.</returns>
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase CSV)
        {
            if (CSV != null && CSV.ContentLength > 0)
            {
                var FileName = Path.GetFileName(CSV.FileName);
                CSV.SaveAs(Server.MapPath("~/Content/") + CSV.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/"), FileName);
                TempData["FilePath"] = path;

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// Clears table in database so new data can be added.
        /// </summary>
        /// <param name="dataBase">Table to be cleared.</param>
        public void ClearTable(EmployeeModelContainer dataBase)
        {
            var ToBeDeleted =
                                from rows in dataBase.EmployeesDBs
                                where rows.EmpID <= 1000000
                                select rows;

            foreach (var rows in ToBeDeleted)
            {
                dataBase.EmployeesDBs.Remove(rows);
            }

            dataBase.SaveChanges();
        }

        /// <summary>
        /// Populates table in database with parsed data.
        /// </summary>
        /// <param name="dataBase">Database to be filled</param>
        /// <param name="employees">List of instances of <see cref="Employee"/>class containing employee data that has been parsed.</param>
        public void PopulateTable(EmployeeModelContainer dataBase, List<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                if (emp.Salary == Decimal.MinValue)
                { emp.Salary = 0; }

                if (emp.Birthdate == DateTime.MinValue)
                { emp.Birthdate = DateTime.Parse("07/04/1776"); }

                if (emp.DateHired == DateTime.MinValue)
                { emp.DateHired = DateTime.Parse("07/04/1776"); }

                var DBEmp = new EmployeesDB { FullName = emp.FullName, Birthdate = emp.Birthdate, Salary = emp.Salary, DateHired = emp.DateHired, Guid = emp.Id, IsValid = emp.IsValid, PrintIfValid = emp.PrintIfValid };
                dataBase.EmployeesDBs.Add(DBEmp);
                dataBase.SaveChanges();
            }
        }

    }
}