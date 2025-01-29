using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.ECS.Components
{
    public struct TypeComponent
    {
        public string Type;

        public static TypeComponent Create(string type)
        {
            return new TypeComponent()
            {
                Type = type
            };
        }
    }
}
