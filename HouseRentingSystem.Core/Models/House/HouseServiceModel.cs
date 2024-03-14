using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.House;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = StringLengthError)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredError)]
        [StringLength(AddressMaxLength,
           MinimumLength = AddressMinLength,
           ErrorMessage = StringLengthError)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredError)]

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredError)]
        [Range(typeof(decimal), MinPricePerMonth,
            MaxPricePerMonth,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = PriceRangeError)]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Is Rented")]
        public bool IsRented {  get; set; }

        
    }
}
