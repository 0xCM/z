//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.ComponentModel;

    partial class ClrQuery
    {
        /// <summary>
        /// Gets the display name specified by the eponymous attribute, if attributed; otherwise, returns the reflected property name
        /// </summary>
        /// <param name="src">The source property</param>
        [Op]
        public static string DisplayName(this PropertyInfo src)
            => (from a in src.Tag<DisplayNameAttribute>()
                    select a.DisplayName).ValueOrElse(() => src.Name);
    }
}