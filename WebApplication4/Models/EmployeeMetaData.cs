using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication4.Controllers;

namespace WebApplication4.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {

    }
    public class EmployeeMetaData
    {
        [Required(ErrorMessage = "This is Required")]
        public string EmpName { get; set; }
    }
}