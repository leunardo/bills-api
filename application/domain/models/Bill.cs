using System;
using infrastructure.records;

namespace application.domain.models
{
    public class Bill
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal AdjustedAmount { get; set; }
        public int OverdueDays { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime DueDate { get; set; }

        public Bill() { }
        public Bill(BillRecord record)
        {
            this.Id = record.Id;
            this.Name = record.Name;
            this.OriginalAmount = record.Amount;
            this.OverdueDays =  CalculateOverdueDays(record);
            this.PaymentDate = record.PaymentDate;
            this.DueDate = record.DueDate;
        }

        private int CalculateOverdueDays(BillRecord record)
        {
            var paymentDate = record.PaymentDate.HasValue
                ? record.PaymentDate.Value
                : DateTime.Now;

            var overdueDays = (int)paymentDate.Subtract(record.DueDate).TotalDays;

            if (overdueDays > 0) {
                return overdueDays;
            } else {
                return 0;
            }
        }
    }
}