using System.ComponentModel.DataAnnotations;

namespace ClientApp.Model
{
    public class Contact
    {
        public Guid id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public int age { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string address { get; set; }


    }
}
