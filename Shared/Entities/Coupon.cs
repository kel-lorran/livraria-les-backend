using System;

namespace Shared
{
    public class Coupon : Identity<Coupon, int>
    {
        public float Value { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int? CustomerId { get; set; }
    }
}