//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Computes the effective type of the source <see cref='Type'/>
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static Type EffectiveType(this Type src)
            => src.UnderlyingSystemType.IsByRef ? src.ElementType() : src;
    }
}