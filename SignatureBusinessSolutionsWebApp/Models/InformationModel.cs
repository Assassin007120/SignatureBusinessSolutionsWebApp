using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SignatureBusinessSolutionsWebApp.Models
{
    public class InformationModel
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Telephone Number")]
        public string TelNo { get; set; }

        [Display(Name = "Cell Number")]
        public string CellNo { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string AddressLine3 { get; set; }

        [Display(Name = "Address Code")]
        public string AddressCode { get; set; }

        [Display(Name = "Postal Address 1")]
        public string PostalAddress1 { get; set; }

        [Display(Name = "Postal Address 2")]
        public string PostalAddress2 { get; set; }

        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }
    }
}