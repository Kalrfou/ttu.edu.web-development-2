using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class FutureValue
    {
        [Required(ErrorMessage = "Present Value is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Present Value must be greater than 0")]
        public double PresentValue { get; set; }

        [Required(ErrorMessage = "Interest Rate is required")]
        [Range(0.001, 1, ErrorMessage = "Interest Rate must be between 0 and 1")]
        public double InterestRate { get; set; }

        [Required(ErrorMessage = "Years is required")]
        [Range(1, 100, ErrorMessage = "Years must be between 1 and 100")]
        public int Years { get; set; }

        public double CalculateFutureValue()
        {
            return PresentValue * Math.Pow(1 + InterestRate, Years);
        }
    }
}