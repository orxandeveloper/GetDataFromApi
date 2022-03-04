using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDFA.Application.Attributes
{
    internal class HeaderProperty:Attribute//: JsonPropertyAttribute (this is sealed class)
    {
        private readonly JsonPropertyAttribute jpa;
        public HeaderProperty(string propName)
        {
            jpa= new JsonPropertyAttribute(propName);
        }
    }
}
