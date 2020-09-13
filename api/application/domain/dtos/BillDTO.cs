using System;

namespace application.domain.dtos
{
    public class BillDTO
    {
        public string Name { get; set; }
        public decimal OriginalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}