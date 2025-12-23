namespace Project1.Models
{
    public class FutureValue
    {
       
        public double PresentValue { get; set; }
        public double InterestRate { get; set; }
        public int Years { get; set; }

        public double CalculateFutureValue()
        {
            return PresentValue * Math.Pow(1 + InterestRate, Years);
        }
    }
}
