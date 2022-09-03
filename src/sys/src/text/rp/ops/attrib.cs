//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Renders an attribute '{name}:{value};
        /// </summary>
        /// <param name="name">The attribute name</param>
        /// <param name="value">The attribute value</param>
        [Op, Closures(Closure)]
        public static string attrib<T>(string name, T value)
            => string.Format(Attrib, name, denullify(value));

        /// <summary>
        /// Renders an attribute '{name,{pad}}:{value}
        /// </summary>
        /// <param name="name">The attribute name</param>
        /// <param name="value">The attribute value</param>
        [Op, Closures(Closure)]
        public static string attrib<T>(int pad, string name, T value)
            => string.Format(Attrib, string.Format(RP.pad(pad), name), denullify(value));
    }
}