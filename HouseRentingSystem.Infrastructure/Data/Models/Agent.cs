using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.Agent;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
	[Index(nameof(PhoneNumber), IsUnique = true)]
	[Comment("House agent")]
	public class Agent
	{
		[Key]
		[Comment("Agent identifier")]
        public int Id { get; set; }

		[Required]
		[MaxLength(PhoneNumberMaxLength)]
		[Comment("Agent phone number")]
		public string PhoneNumber { get; set; } = string.Empty;

		[Required]
		[Comment("Agent user identifier")]
		public string UserId { get; set; } = string.Empty;
		[ForeignKey(nameof(UserId))]
		public IdentityUser User { get; set; } = null!;

		public List<House> Houses { get; set; } = new List<House>();
	}
}



