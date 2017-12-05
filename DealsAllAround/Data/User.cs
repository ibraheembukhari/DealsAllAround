namespace DealsAllAround.DataAccess
{
    public class User
    {
     
        public string name { get; set; }

        //[Required (ErrorMessage ="Email is Required.")]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Email format is not correct.")]
        //[Display(Name = "E-mail")]
        public string email { get; set; }
        public string password { get; set; }
        public int contact { get; set; }
        public string brand { get; set; }
        public string address { get; set; }
        public string message { get; set; }
      

    }
}
