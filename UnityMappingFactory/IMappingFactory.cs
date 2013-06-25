using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityMappingFactory
{
    /// <summary>
    /// Defines the mapping between one set of objects and another set of objects.
    /// </summary>
    /// <remarks>
    /// In general, you can think of the TFrom object providing the initialization of the TTo objects.
    /// Often, the TTo objects will simply be wrappers around the TFrom objects which is the case when
    /// mapping a Model class hierarchy to a ViewModel class hierarchy.
    /// </remarks>
    /// <typeparam name="TFrom">The type of object to convert from at its most base point in the object hierarchy.</typeparam>
    /// <typeparam name="TTo">The type of object to return at its most base point in the object hierarchy.</typeparam>
    public interface IMappingFactory<TFrom, TTo>
    {
        /// <summary>
        /// Adds a default mapping between the TFrom and TTo types to this mapping definition.
        /// </summary>
        /// <remarks>
        /// Used mostly when mapping between just objects and not object hierarchies.
        /// </remarks>
        /// <returns></returns>
        IMappingFactory<TFrom, TTo> AddDefaultMap();

        /// <summary>
        /// A type-safe way to add a mapping between some sub-class of the TFrom class to a 
        /// sub-class of the TTo class. This is normally used when mapping between two different 
        /// class hierarchies.
        /// </summary>
        /// <remarks>
        /// Preferred way to add mappings because it is type-safe.
        /// Follows the general Unity API that specifies both a Type-safe and generic way to do things. 
        /// </remarks>
        /// <typeparam name="UChildOfFrom">A child of the TFrom class which will get mapped.</typeparam>
        /// <typeparam name="UChildOfTo">A child of the TTo class that will be returned.</typeparam>
        /// <returns>
        /// The updated MappingFactory so that additional mappings can be chained together easily.
        /// </returns>
        IMappingFactory<TFrom, TTo> AddMap<UChildOfFrom, UChildOfTo>()
            where UChildOfFrom : TFrom
            where UChildOfTo : TTo;

        /// <summary>
        /// A generic way to add a mapping between some sub-class of the TFrom class to a sub-class of 
        /// the TTo class. This is normally used when mapping between two different class hierarchies.
        /// </summary>
        /// <remarks>
        /// This way can be used to dynamically specify mappings at run-time if neccessary.
        /// Follows the general Unity API that specifies both a Type-safe and generic way to do things. 
        /// </remarks>
        /// <param name="ChildOfFrom">A child of the TFrom class which will get mapped.</param>
        /// <param name="ChildOfTo">A child of the TTo class that will be returned.</param>
        /// <returns>
        /// The updated MappingFactory so that additional mappings can be chained together easily.
        /// </returns>
        IMappingFactory<TFrom, TTo> AddMap(Type ChildOfFrom, Type ChildOfTo);
    }
}
