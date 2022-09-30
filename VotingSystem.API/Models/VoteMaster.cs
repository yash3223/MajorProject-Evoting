using System.ComponentModel.DataAnnotations;

namespace SmartVotingSystem.Models
{
    public class VoteMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VoterId { get; set; }

        [Required]
        public string VoterName { get; set; }

        [Required]
        public string PartyVoted { get; set; }

        [Required]
        public string VotedPartyType { get; set; }
    }
}
