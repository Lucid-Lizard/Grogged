using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.Core
{
    public static class ECSExtensions
    {
        public static T Component<T>(this int ID) where T : class
        {
            return Game1._ecsCoordinator._EntityManager.GetComponent<T>(ID) as T;
        }
    }
}
