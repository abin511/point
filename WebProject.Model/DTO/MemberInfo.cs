using System;

namespace WebProject.Model
{
    public class MemberRegisterRequest
    {
        public string mobile_phone { get; set; }
        public string portrait { get; set; }
        public string pass_word { get; set; }
        public string display_name { get; set; }
        public GenderMenu gender { get; set; }
        public string location_area { get; set; }
        public DateTime? birthday { get; set; }
        public int mobile_code { get; set; }
    }
    public class Member
    {
        public int id { get; set; }
        public string mobile_phone { get; set; }
        public string display_name { get; set; }
        public GenderMenu gender { get; set; }
        public DateTime? birthday { get; set; }
    }

    public class MemberLoginResponse
    {
        public int id { get; set; }
        public string mobile { get; set; }
        public string portrait { get; set; }
        public string display_name { get; set; }
        public GenderMenu gender { get; set; }
        public string location_area { get; set; }
        public DateTime? birthday { get; set; }
        public decimal account_balance { get; set; }
        public decimal amount_total { get; set; }
        public decimal amount_withdrawn { get; set; }
        public decimal total_score { get; set; }
        public decimal total_withdraw_score { get; set; }
        public string token { get; set; }
    }

    public class MemberModifyRequest
    {
        public string portrait { get; set; }
        public string display_name { get; set; }
        public GenderMenu gender { get; set; }
        public string location_area { get; set; }
        public DateTime? birthday { get; set; }
    }
}
