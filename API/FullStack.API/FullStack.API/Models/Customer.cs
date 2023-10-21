namespace FullStack.API.Models
{
    public class Customer
    {
        public Guid id { get; set; }
        //salutation: string,
        //initials: string,
        public string firstname { get; set; }
        // firstname_ascii: string,
        public string gender { get; set; }
        // firstname_country_rank: string,
        // firstname_country_frequency: string,
        public string lastname { get; set; }
        // lastname_ascii: string,
        //  lastname_country_rank: string,
        // lastname_country_frequency: string,
        public string email { get; set; }
        // password: string,
        public string country_code { get; set; }
        // country_code_alpha: string,
        // country_name: string,
        // primary_language_code: string,
        // primary_language: string,
        public int balance { get; set; }
        public string phone_Number { get; set; }
        //currency: string,
    }
}
