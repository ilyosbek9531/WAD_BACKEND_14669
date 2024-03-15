using System.ComponentModel.DataAnnotations;

namespace WAD_BACKEND_14669.Utils
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MinWordsException : ValidationAttribute
    {
        private readonly int _minWords;

        public MinWordsException(int minWords) : base($"The field must have at least {minWords} words.")
        {
            _minWords = minWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is string stringValue)
            {
                string[] words = stringValue.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (words.Length < _minWords)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}


