//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = AsciTables;

    /// <summary>
    /// Defines a contiguous sequence of ascii character codes/characters
    /// </summary>
    public readonly struct AsciTable
    {
        public readonly AsciTableKind Kind;

        public readonly sbyte Count;

        /// <summary>
        /// Specifies the first code value
        /// </summary>
        public readonly sbyte MinValue;

        /// <summary>
        /// Specifies the last code value
        /// </summary>
        public readonly sbyte MaxValue;

        /// <summary>
        /// Specifies the first code
        /// </summary>
        public readonly AsciCode MinCode;

        /// <summary>
        /// Specifies the last code
        /// </summary>
        public readonly AsciCode MaxCode;

        /// <summary>
        /// Specifies the first symbol
        /// </summary>
        public readonly AsciSymbol MinSymbol;

        /// <summary>
        /// Specifies the last symbol
        /// </summary>
        public readonly AsciSymbol MaxSymbol;

        [MethodImpl(Inline), Op]
        public AsciTable(AsciTableKind kind, AsciCode min, AsciCode max)
        {
            Kind = kind;
            MinCode = min;
            MaxCode = max;
            MinSymbol = min;
            MaxSymbol = max;
            MinValue = (sbyte)min;
            MaxValue = (sbyte)max;
            Count = (sbyte)((sbyte)(MaxValue - MinValue) + 1);
        }

        /// <summary>
        /// Specifies the represented<see cref='AsciCode'/> sequence
        /// </summary>
        public ReadOnlySpan<AsciCode> Codes
        {
            [MethodImpl(Inline), Op]
            get => api.codes(MinValue, Count);
        }

        /// <summary>
        /// Specifies the represented<see cref='AsciSymbol'/> sequence
        /// </summary>
        public ReadOnlySpan<AsciSymbol> Symbols
        {
            [MethodImpl(Inline), Op]
            get => api.symbols(MinValue,Count);    
        }

        /// <summary>
        /// Specifies the represented<see cref='char'/> sequence
        /// </summary>
        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline), Op]
            get => api.chars(MinValue,Count);
        }
    }
}