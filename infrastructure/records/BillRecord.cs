using System;

namespace infrastructure.records
{
    public class BillRecord
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}