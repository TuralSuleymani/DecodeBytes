using LearningAspNETCOREWebAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearningAspNETCOREWebAPI.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }
        public AccounType AccounType { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();

    }
}
