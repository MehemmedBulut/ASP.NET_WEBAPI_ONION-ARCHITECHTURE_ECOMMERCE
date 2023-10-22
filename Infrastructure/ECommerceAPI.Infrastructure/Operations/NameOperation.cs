using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Operations
{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string name)
        => name.Replace("/", "")
                .Replace("!", "")
                .Replace("'", "")
                .Replace("^", "")
                .Replace("@", "")
                .Replace("+", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("_", "")
                .Replace("=", "")
                .Replace(",", "")
                .Replace(":", "")
                .Replace(".", "_")
                .Replace("Ö", "o")
                .Replace("ö", "o")
                .Replace("Ü", "u")
                .Replace("ü", "u")
                .Replace("I", "i")
                .Replace("ı", "i")
                .Replace("ğ", "g")
                .Replace("Ğ", "g")
                .Replace("Ş", "s")
                .Replace("ş", "s")
                .Replace("Ç", "c")
                .Replace("ç", "c")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        
    }
}
