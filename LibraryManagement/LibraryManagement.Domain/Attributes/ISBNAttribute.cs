using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Attributes
{
    public class ISBNAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string isbn = value as string;

            // ISBN Nummer prüfen!

            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            return true;
        }
    }
}
