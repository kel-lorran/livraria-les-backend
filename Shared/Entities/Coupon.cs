using System;

namespace Shared
{
    public class Coupon : Identity<Coupon, int>
    {
        public Coupon()
        {
        }

        public Coupon(string code)
        {
            Code = code;
        }

        public Coupon(float value, string status, string type, string code, DateTime date)
        {
            Value = value;
            Status = status;
            Type = type;
            Code = code;
            Date = date;
        }

        public float Value { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int? CustomerId { get; set; }
    }
}