using System;

namespace Models.Model
{
    public class Sales
    {
        public int SalesId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int InstallmentId { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
