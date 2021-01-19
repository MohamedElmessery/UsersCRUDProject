using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDProject.Models
{
    //Form Api
    public class UserData
    {
        public int User_Id { get; set; }
        [Display(Name ="Name"),Required(ErrorMessage ="User Name is Required")]
        public string User_Name { get; set; }
        [Display(Name = "Age"),Required(ErrorMessage = "Age is Required"),Range(14,30)]
        public Nullable<int> User_Age { get; set; }
        [Display(Name = "Adress"),Required(ErrorMessage ="User Name is Required")]
        public string User_Adress { get; set; }
    }
}