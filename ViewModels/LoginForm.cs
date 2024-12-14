using System.ComponentModel.DataAnnotations;

namespace E_Commerce.ViewModels
{
    public class LoginForm
    {
        [Required(ErrorMessage = "This Field is Required")]
       
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }


    }
}
