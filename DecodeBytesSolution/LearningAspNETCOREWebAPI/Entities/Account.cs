using LearningAspNETCOREWebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAspNETCOREWebAPI.Entities
{
    public enum AccounType
    {
        Main,
        Sub
    }

    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Number { get; set; }
        public AccounType AccounType { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();

    }
}
