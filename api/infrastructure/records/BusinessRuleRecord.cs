namespace infrastructure.records
{
    public class BusinessRuleRecord
    {
        public string Id { get; set; }
        public int DelayedDaysStart { get; set; }
        public int DelayedDaysEnd { get; set; }
        public double Penalty { get; set; }
        public double InterestPerDay { get; set; }
    }
}