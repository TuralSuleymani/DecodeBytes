using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace LearningAspNETCOREWebAPI.Models
{
    public class CreateCard
    {
        [StringLength(maximumLength:20,MinimumLength =12, ErrorMessage = "Holder name is invalid and it should be between 12-20 symbols")]
        public string HolderName { get; set; }

        [RegularExpression("\\d{2}/\\d{2}")]
        public string ExpireDate { get; set; }

        [RegularExpression("\\d{4}-\\d{4}-\\d{4}-\\d{4}")]
        public string Number { get; set; }
    }
}
