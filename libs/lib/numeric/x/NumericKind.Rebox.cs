//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class XTend
    {
        /// <summary>
        /// Convers a source value, which is hopefully a supported kind, to a target kind
        /// </summary>
        /// <param name="k">The primal kind</param>
        [MethodImpl(Inline), Op]
        public static object Rebox(this NumericKind dst, object src)
            => NumericBox.rebox(src,dst);
    }
}