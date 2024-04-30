using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAspNETCOREWebAPI.Entities
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string HolderName { get; set; }

        [Required]
        [StringLength(maximumLength:5,MinimumLength =5)]
        public string ExpireDate { get; set; } 

        [Required]
        [StringLength(maximumLength:19,MinimumLength =19)]
        public string Number { get; set; }//4444-5555-3333-6767
    }
}
