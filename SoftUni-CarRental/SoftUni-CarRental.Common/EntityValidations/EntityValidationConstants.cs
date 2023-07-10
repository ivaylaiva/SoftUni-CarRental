namespace SoftUni_CarRental.Common.EntityValidations
{
    public static class EntityValidationConstants
    {
        public static class Car
        {
            public const int MinModelLength = 5;
            public const int MaxModelLength = 50;

            public const int MinColourLength = 3;
            public const int MaxColourLength = 50;

            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1500;
        }
        public static class CarCard
        {
            public const int MinButtonLabelLength = 3;
            public const int MaxButtonLabelLength = 30;
        }
        public static class Comment
        {
            public const int MinDescriptionLengthForComment = 20;
            public const int MaxDescriptionLengthForComment = 1500;
        }
        public static class Message
        {
            public const int MinFirstNameLength = 2;
            public const int MaxFirstNameLength = 30;

            public const int MinLastNameLength = 2;
            public const int MaxLastNameLength = 30;

            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1500;
        }
    }
}
