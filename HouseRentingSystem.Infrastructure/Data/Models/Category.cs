using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.Category;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
	[Comment("House category")]
	public class Category
	{
		[Key]
		[Comment("Category identifier")]
        public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		[Comment("Category name")]
		public string Name { get; set; } = string.Empty;

		public List<House> Houses { get; set; } = new List<House>();	
    }
}
