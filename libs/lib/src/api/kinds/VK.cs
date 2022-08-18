//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class VK
    {
        const NumericKind Closure = AllNumeric;

        /// <summary>
        /// Closed vector types of width 128
        /// </summary>
        [Op]
        public static ReadOnlySpan<Type> Types128()
            => NumericKinds.NumericTypes().Select(t => typeof(Vector128<>).MakeGenericType(t));

        /// <summary>
        /// Closed vector types of width 256
        /// </summary>
        [Op]
        public static ReadOnlySpan<Type> Types256()
            => NumericKinds.NumericTypes().Select(t => typeof(Vector256<>).MakeGenericType(t));

        /// <summary>
        /// Closed vector types of width 512
        /// </summary>
        [Op]
        public static ReadOnlySpan<Type> Types512()
            => NumericKinds.NumericTypes().Select(t => typeof(Vector512<>).MakeGenericType(t));
    }
}