//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static AsciChars;

    /// <summary>
    /// Defines a contiguous sequence of ascii character codes/characters
    /// </summary>
    public readonly struct AsciTable
    {
        /// <summary>
        /// Returns the asci characters corresponding to the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of characters to select</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(sbyte offset, sbyte count)
            => slice(recover<char>(CharBytes), offset, count);

        /// <summary>
        /// Returns the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of codes to select</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciCode> codes(sbyte offset, sbyte count)
            => recover<AsciCode>(slice(AsciChars.CodeBytes, offset, count));

        public readonly AsciTableKind Kind;

        public readonly sbyte Count;

        /// <summary>
        /// Specifies the first code
        /// </summary>
        readonly sbyte Min;

        /// <summary>
        /// Specifies the last code
        /// </summary>
        readonly sbyte Max;

        [MethodImpl(Inline), Op]
        public AsciTable(AsciTableKind kind, AsciCode min, AsciCode max)
        {
            Kind = kind;
            Min = (sbyte)min;
            Max = (sbyte)max;
            Count = (sbyte)((sbyte)(Max - Min) + 1);
        }

        /// <summary>
        /// Specifies the represented<see cref='AsciCode'/> sequence
        /// </summary>
        public ReadOnlySpan<AsciCode> Codes
        {
            [MethodImpl(Inline), Op]
            get => codes(Min, Count);
        }

        /// <summary>
        /// Specifies the represented<see cref='AsciSymbol'/> sequence
        /// </summary>
        public ReadOnlySpan<AsciSymbol> Symbols
        {
            [MethodImpl(Inline), Op]
            get => recover<AsciCode,AsciSymbol>(Codes);
        }

        /// <summary>
        /// Specifies the represented<see cref='char'/> sequence
        /// </summary>
        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline), Op]
            get => chars(Min,Count);
        }
    }
}