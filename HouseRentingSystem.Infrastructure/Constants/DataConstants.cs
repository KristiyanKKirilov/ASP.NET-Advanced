namespace HouseRentingSystem.Infrastructure.Constants
{
	public static class DataConstants
	{
		public static class Category
		{
			/// <summary>
			/// Category name maximum length
			/// </summary>
			public const int NameMaxLength = 50;
		}

		public static class House
		{
			/// <summary>
			/// House title min length
			/// </summary>
			public const int TitleMinLength = 10;

			/// <summary>
			/// House title max length
			/// </summary>
			public const int TitleMaxLength = 50;

			/// <summary>
			/// House address min length
			/// </summary>
			public const int AddressMinLength = 30;

			/// <summary>
			/// House address max length
			/// </summary>
			public const int AddressMaxLength = 150;

			/// <summary>
			/// House description min length
			/// </summary>
			public const int DescriptionMinLength = 50;

			/// <summary>
			/// House description max length
			/// </summary>
			public const int DescriptionMaxLength = 500;

			/// <summary>
			/// House min price per month 
			/// </summary>
			public const string MinPricePerMonth = "0.00";

			/// <summary>
			/// House max price per month 
			/// </summary>
			public const string MaxPricePerMonth = "2000.00";
		}

		public static class Agent
		{
			/// <summary>
			/// Agent phone number min length
			/// </summary>
			public const int PhoneNumberMinLength = 7;

			/// <summary>
			/// Agent phone number max length
			/// </summary>
			public const int PhoneNumberMaxLength = 15;
		}
	}
}
