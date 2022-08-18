//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = TokenStrings;

    /// <summary>
    /// Defines a sequence of null-delemited character sequences
    /// </summary>
    public readonly struct TokenString
    {
        public readonly Index<char> Content;

        public TokenString(char[] src)
        {
            Content = src;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Content.View;
        }

        /// <summary>
        /// The subsequence count
        /// </summary>
        public uint TokenCount
        {
            [MethodImpl(Inline)]
            get => api.count(this);
        }
    }
}