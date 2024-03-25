using HouseRentingSystem.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.House;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseFormModel : IHouseModel
    {
        [Required(ErrorMessage = RequiredError)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = StringLengthError)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredError)]
        [StringLength(AddressMaxLength,
            MinimumLength = AddressMinLength,
            ErrorMessage = StringLengthError)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredError)]
        [StringLength(DescriptionMaxLength,
             MinimumLength = DescriptionMinLength,
            ErrorMessage = StringLengthError)]

        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredError)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredError)]
        [Range(typeof(decimal), MinPricePerMonth, 
            MaxPricePerMonth, 
            ConvertValueInInvariantCulture = true,
            ErrorMessage = PriceRangeError)]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }  

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } = new List<HouseCategoryServiceModel>();

    }
}
