namespace DealsAllAround.DataAccess
{
    public class User
    {
        //[Required (ErrorMessage ="Name is Required.")]
        //[Display(Name = "Name")]
        public string name { get; set; }

        //[Required (ErrorMessage ="Email is Required.")]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Email format is not correct.")]
        //[Display(Name = "E-mail")]
        public string email { get; set; }

        //[Required(ErrorMessage = "Password is Required.")]
        //[Display(Name = "Password")]
        public string password { get; set; }

        //[Required(ErrorMessage = "Contact Number is Required.")]
        //[Display(Name = "Contact Number")]
        public int contact { get; set; }

        //[Required(ErrorMessage = "Brand Name is Required.")]
        //[Display(Name = "Brand Name")]
        public string brand { get; set; }

        //[Required(ErrorMessage = "Address is Required.")]
        //[Display(Name = "Your Address")]
        public string address { get; set; }

        //[Required(ErrorMessage = "Message is Required.")]
        //[Display(Name = "Any Message")]
        public string message { get; set; }
      

    }
}
