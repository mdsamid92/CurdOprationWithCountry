using CurdOprationWithCountry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CurdOprationWithCountry.Controllers
{
    public class EmpController : Controller
    {
        private readonly DatabaseContext _context;

        public EmpController(DatabaseContext context)
        {
            _context = context;
        }

        private void FillCountries()
        {
            List<SelectListItem> countries = (from c in _context.Countries
                                              orderby c.Name ascending
                                              select new SelectListItem()
                                              {
                                                 Text = c.Name, Value = c.Name
                                              }).ToList();
               ViewBag.countries = countries;                     
        }
        [HttpGet]
           
        public IActionResult Create()
        {
            FillCountries();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            FillCountries();
            if(ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            List<Employee> model = (from e in _context.Employees
                                    orderby e.EmployeeID
                                    select e).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee model = _context.Employees.Find(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee model = _context.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteAction(int id )
        {
            var data = _context.Employees.Find(id);
            _context.Employees.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            FillCountries();
            Employee model = _context.Employees.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Employees.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
