using System.ComponentModel.DataAnnotations;

namespace CurdOprationWithCountry.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }


    }
}
