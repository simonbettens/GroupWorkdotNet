using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models
{
    public class AccountLoginViewModel
    {
        [Required(ErrorMessage = "Dit veld is verplicht")]
        //[Compare("ListActiveUsers")] -> nog zien hoe we de echte users ophalen
        [Display(Name = "Username", Prompt = "Gebruikersnaam")]
        [DataType(DataType.EmailAddress)] //ervan uitgegaan dat username altijd hogent email is
        [RegularExpression(@"[A-Za-z0-9._%+-]+@(student.)? hogent.be)")]
        public string Username
        {
            get; private set;
        }
        
    }
}
