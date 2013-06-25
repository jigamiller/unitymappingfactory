using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace UnityMappingFactory
{
    /// <summary>
    /// Contains Factory mapping extensions to the <seealso cref="IUnityContainer"/>.
    /// </summary>
    public static class UnityMappingFactoryExtensions
    {
        #region private sealed class MappingFactory<TFrom, TTo> : IMappingFactory<TFrom, TTo>, IFactory<TFrom, TTo>

        /// <summary>
        /// Holds the dependency mapping registered during configuration between one class (or class hierarchy)
        /// containing the initialization information needed in order to create another class (or class hierarchy).
        /// </summary>
        /// <typeparam name="TFrom">The type of class (or class hierarchy) containing the initialization information.</typeparam>
        /// <typeparam name="TTo">The type of class (or class hierarchy) to be created.</typeparam>
        private sealed class MappingFactory<TFrom, TTo> : IMappingFactory<TFrom, TTo>, IFactory<TFrom, TTo>
        {
            /// <summary>
            /// The Unity container that we holds all of the normal dependency mappings. We will use it to 
            /// resolve any dependencies during class creation.
            /// </summary>
            private readonly IUnityContainer _container;

            /// <summary>
            /// Holds the mappings between one class (or class hierarchy) as the TKey used to initialize
            /// and another class (or class hierarchy) as the TValue which will be created.
            /// </summary>
            private IDictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

            /// <summary>
            /// Initializes a new instance of the <see cref="MappingFactory{TFrom, TTo}"/> class.
            /// </summary>
            /// <param name="container">The parent Unity container holding all the dependency mappings.</param>
            public MappingFactory(IUnityContainer container)
            {
                _container = container;
            }

            /// <summary>
            /// A type safe way that attempts to create the Type mapped as UChildTo and initialize it with the 
            /// Type mapped as UChildFrom along with any other dependencies neccessary by utilizing the Unity 
            /// IoC container's Resolve() method and injecting the UChildFrom object instance as a <seealso cref="DependencyOverride"/>.
            /// </summary>
            /// <remarks>
            /// Preferred way to attempt a resolution because it is type-safe.
            /// Follows the general Unity API that specifies both a Type-safe and generic way to do things. 
            /// </remarks>
            /// <typeparam name="UChildFrom">
            /// The TFrom Type or an inherited Type of the TFrom Type which will get used to create the TTo return value.
            /// </typeparam>
            /// <typeparam name="UChildTo">
            /// The TTo Type or an inherited Type that will be created using the passed in value.
            /// </typeparam>
            /// <param name="value">
            /// The object instance of type TFrom (or an inherited Type) which will be used to create the return value.
            /// </param>
            /// <param name="result">
            /// If successful, the object instance of type TTo (or an inherited Type) which was created using the passed in value; ohterwise, <c>null</c>.
            /// </param>
            /// <returns>
            /// <c>true</c> if a child control was created and initialized; otherwise, <c>false</c>.
            /// </returns>
            private bool TryResolve<UChildFrom, UChildTo>(TFrom value, out TTo result)
            {
                return this.TryResolve(typeof(UChildFrom), typeof(UChildTo), value, out result);
            }

            /// <summary>
            /// A generic way that can be utilized at run-time to attempts to create the Type mapped as UChildTo 
            /// and initialize it with the Type mapped as UChildFrom along with any other dependencies neccessary 
            /// by utilizing the Unity IoC container's Resolve() method and injecting the UChildFrom object instance
            /// as a <seealso cref="DependencyOverride"/>.
            /// </summary>
            /// <remarks>
            /// Probably not neccessary but follows the general Unity API.
            /// Follows the general Unity API that specifies both a Type-safe and generic way to do things. 
            /// </remarks>
            /// <typeparam name="UChildFrom">
            /// The TFrom Type or an inherited Type of the TFrom Type which will get used to create the TTo return value.
            /// </typeparam>
            /// <typeparam name="UChildTo">
            /// The TTo Type or an inherited Type that will be created using the passed in value.
            /// </typeparam>
            /// <param name="value">
            /// The object instance of type TFrom (or an inherited Type) which will be used to create the return value.
            /// </param>
            /// <param name="result">
            /// If successful, the object instance of type TTo (or an inherited Type) which was created using the passed in value; ohterwise, <c>null</c>.
            /// </param>
            /// <returns>
            /// <c>true</c> if a child control was created and initialized; otherwise, <c>false</c>.
            /// </returns>
            private bool TryResolve(Type UChildFrom, Type UChildTo, TFrom value, out TTo result)
            {
                result = default(TTo);
                if (UChildFrom.IsAssignableFrom(value.GetType()))
                    result = (TTo)_container.Resolve(UChildTo, new DependencyOverride(UChildFrom, value));
                return (result != null);
            }

            #region IMappingFactory Members
            public IMappingFactory<TFrom, TTo> AddDefaultMap()
            {
                this._mappings.Add(typeof(TFrom), typeof(TTo));
                return this;
            }

            public IMappingFactory<TFrom, TTo> AddMap<UChildOfFrom, UChildOfTo>()
                where UChildOfFrom : TFrom
                where UChildOfTo : TTo
            {
                this.AddMap(typeof(UChildOfFrom), typeof(UChildOfTo));
                return this;
            }

            public IMappingFactory<TFrom, TTo> AddMap(Type ChildOfFrom, Type ChildOfTo)
            {
                this._mappings.Add(ChildOfFrom, ChildOfTo);
                return this;
            }
            #endregion

            #region IFactory Members

            public TTo Create(TFrom value)
            {
                TTo result = default(TTo);
                foreach (var map in _mappings)
                {
                    if (this.TryResolve(map.Key, map.Value, value, out result))
                        break;
                }
                //if (result == null) throw new ArgumentOutOfRangeException("requestedType", string.Format("Unknown control type '{0}'!", value.GetType()));
                return result;
            }

            #endregion IFactory Members
        }

        #endregion

        /// <summary>
        /// Registers a class factory that will create new objects based on data from existing objects mapping
        /// from one object (or object hierarchy) to a different object (or object hierarchy).
        /// </summary>
        /// <remarks>
        /// The factory gets registered as a singleton using the <seealso cref="ContainerControlledLifetimeManager"/>
        /// and I have not provided an override since I could not come up with non-contrived scenario where it 
        /// was neccessary.
        /// </remarks>
        /// <typeparam name="TFrom">The type of objects containing the initialization data.</typeparam>
        /// <typeparam name="TTo">The type of objects to be created by the factory.</typeparam>
        /// <param name="container">The Unity container that we are extending.</param>
        /// <returns>
        /// The <seealso cref="IMappingFactory"/> to configure the actual mappings that will take place at run-time.
        /// </returns>
        public static IMappingFactory<TFrom, TTo> RegisterFactory<TFrom, TTo>(this IUnityContainer container)
        {
            var result = new MappingFactory<TFrom, TTo>(container);
            container.RegisterInstance<IFactory<TFrom, TTo>>(result, new ContainerControlledLifetimeManager());
            return result; 
        }
    }
}
