using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRegisterAPI.Models
{
    public class PhotographyVendor
    {

        [Key]
        public int EmployeeID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string EmployeeName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Occupation { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Located_distric { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Located_province { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Min_package { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Max_package { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string TelephoneNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CompanyWebsite { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
    }
}
