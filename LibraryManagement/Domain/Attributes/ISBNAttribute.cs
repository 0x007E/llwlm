using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Attributes
{
    public class ISBNAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string isbn = value as string;

            if (isbn is null)
                return false;

            // Komplizierte Berechnung der ISBN

            return true;
        }
    }
}
