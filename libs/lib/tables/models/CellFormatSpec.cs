//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines formatting specifications for a cell
    /// </summary>
    public readonly struct CellFormatSpec
    {
        public readonly RenderPattern<dynamic> Pattern;

        public readonly RenderWidth Width;

        [MethodImpl(Inline)]
        public CellFormatSpec(string pattern, RenderWidth width)
        {
            Pattern = pattern;
            Width = width;
        }
    }
}