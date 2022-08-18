//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Gets the static properties declared by a specified type
        /// </summary>
        /// <param name="this">The type to examine</param>
        public static PropertyInfo[] StaticProperties(this Type src)
            => src.GetProperties(BF_Static);

        /// <summary>
        /// Gets the static properties of specified type declared by a specified type
        /// </summary>
        /// <param name="this">The type to examine</param>
        /// <param name="proptype">The property type to match</param>
        public static PropertyInfo[] StaticProperties(this Type src, Type proptype)
            => src.GetProperties(BF_Static).Where(p => p.PropertyType == proptype);

        /// <summary>
        /// Gets the static methods defined on a specified type
        /// </summary>
        /// <param name="this">The type to examine</param>
        /// <param name="get">Specifies whether to require selected properties to provide get accessors</param>
        public static PropertyInfo[] StaticProperties(this Type src, bool get)
            => get ? src.StaticProperties().Where(p => p.HasPublicGetter()) : src.StaticProperties();

        /// <summary>
        /// Gets the static properties defined on a specified type that provided get/set accessors/manipulators
        /// per the provided specifiation
        /// </summary>
        /// <param name="this">The type to examine</param>
        /// <param name="get">Specifies whether to include or exclude properties with get accessors</param>
        /// <param name="set">Specifies whether to include or exclude properties with set accessors</param>
        public static PropertyInfo[] StaticProperties(this Type src, bool get, bool set)
        {
            if(get && set)
                return src.StaticProperties().Where(p => p.HasPublicGetter() && p.HasPublicSetter());
            else if(get && !set)
                return src.StaticProperties().Where(p => p.HasPublicGetter() && !p.HasPublicSetter());
            else if(!get && set)
                return src.StaticProperties().Where(p => !p.HasPublicGetter() && p.HasPublicSetter());
            else
                return src.StaticProperties();
        }
    }
}