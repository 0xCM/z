//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the properties from a stream that reify a specified interface type
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="tInterface">The interface type</param>
        [Op]
        public static PropertyInfo[] Reifies(this PropertyInfo[] src, Type tInterface)
            => src.Where(p => p.PropertyType.Reifies(tInterface));
    }
}