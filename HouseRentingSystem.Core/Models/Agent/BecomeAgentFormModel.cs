using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.Agent;

namespace HouseRentingSystem.Core.Models.Agent
{
	public class BecomeAgentFormModel
	{
        [Required(ErrorMessage = RequiredError)]
        [StringLength(
            PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength,
            ErrorMessage = StringLengthError)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
