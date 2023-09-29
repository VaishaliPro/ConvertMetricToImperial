

namespace ConvertMetricToImperial
{
    public class ConversionRate
    {
        public int Id { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public double Rate { get; set; }
    }
}
