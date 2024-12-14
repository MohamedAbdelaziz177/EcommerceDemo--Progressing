using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace E_Commerce.ViewModels
{

	// ErrorMessage = "This Field is Required"
	public class UserRegForm
	{

		[Required(ErrorMessage = "This Field is Required")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "This Field is Required")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "This Field is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "This Field is Required")]
		[Compare("Password")]
        [DataType(DataType.Password)]

        public string PasswordConfirmed { get; set; }

	
		public string Address {  get; set; }
	}
}
