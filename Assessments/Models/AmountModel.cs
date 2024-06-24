using System.ComponentModel.DataAnnotations;

namespace Assessments.Models
{
    public class AmountModel
    {
        [Required(ErrorMessage = "Please enter an amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid amount")]
        public decimal Amount { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string AmountInWords { get; set; }
    }
}
