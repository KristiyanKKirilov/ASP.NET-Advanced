using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.House;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
	[Comment("House to rent")]
	public class House
	{
		[Key]
		[Comment("House identifier")]
		public int Id { get; set; }

		[Required]
		[MaxLength(TitleMaxLength)]
		[Comment("House title")]
		public string Title { get; set; } = string.Empty;

		[Required]
		[MaxLength(AddressMaxLength)]
		[Comment("House address")]
		public string Address { get; set; } = string.Empty;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		[Comment("House description")]
		public string Description { get; set; } = string.Empty;

		[Required]
		[Comment("House image url")]
		public string ImageUrl { get; set; } = string.Empty;

        [Required]
		[Column(TypeName = "decimal(18,2)")]
		[Comment("Monthly rent")]
		//[Range(typeof(decimal), MinPricePerMonth, MaxPricePerMonth, ConvertValueInInvariantCulture = true)]
        public decimal PricePerMonth { get; set; }

		[Required]
		[Comment("House category identifier")]
        public int CategoryId { get; set; }
		[ForeignKey(nameof(CategoryId))]
		public Category Category { get; set; } = null!;

        [Required]
        [Comment("House agent identifier")]
        public int AgentId { get; set; }
		[ForeignKey(nameof(AgentId))]
		public Agent Agent { get; set; } = null!;

		[Comment("House renter identifier")]
		public string RenterId { get; set; } = string.Empty;
    }
}



