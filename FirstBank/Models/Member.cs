using System;
using System.ComponentModel.DataAnnotations;

namespace FirstBank.Models
{
  public class Member : Person
  {
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Add Account Date")]
    public DateTime AddAccountDate { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}