using ECommerceAPI.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.CustomAttributes
{
    public class AuthorizeDefinitionAttribute:Attribute
    {
        public string Manu { get; set; }
        public string Definition { get; set; }
        public ActionType ActionType { get; set; }
    }
}
