using System.ComponentModel.DataAnnotations;

namespace SmartVotingSystem.Models
{
    public class PartiesMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PartyType { get; set; }

        [Required]
        public string PartyName { get; set; }
    }
}
