using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityMappingFactory
{
    /// <summary>
    /// Defines a very general and simple contract for creating a new object given some existing 
    /// object.
    /// </summary
    /// <remarks>
    /// This is a very generic contract for the Factory design pattern:
    /// http://msdn.microsoft.com/en-us/library/ee817667.aspx
    /// NOTE: It may be a little too generic of a name; however, I liked the short name
    /// when adding it in for consturctor injection.
    /// </remarks>
    /// <typeparam name="TFrom">The type of object to convert from.</typeparam>
    /// <typeparam name="TTo">The type of object to convert to.</typeparam>
    public interface IFactory<TFrom, TTo>
    {
        TTo Create(TFrom value);
    }
}
