//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Produces text in the form {'i' | 'u' | 'f'}
        /// </summary>
        /// <param name="src">The source kind</param>
        [MethodImpl(Inline), Op]
        public static string Format(this NumericIndicator src)
            => NumericKinds.format(src);

        /// <summary>
        /// Produces text in the form {width}{indicator}
        /// </summary>
        /// <param name="k">The source kind</param>
        [MethodImpl(Inline), Op]
        public static string Format(this NumericKind k)
            => NumericKinds.format(k);
    }
}