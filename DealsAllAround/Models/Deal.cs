using System;
namespace DealsAllAround.Models
{
    public class Deal
    {
        public int id { get; set; }     
        public string description { get; set; } 
        public int price { get; set; }
        public string image { get; set; }
        public DateTime createddate { get; set; }
    }
}
