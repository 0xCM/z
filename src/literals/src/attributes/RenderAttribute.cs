//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RenderAttribute : Attribute
    {
        public RenderAttribute(uint width)
        {
            Width = width;
            Style = 0;
        }

        public RenderAttribute(uint width, ulong style)
        {
            Width = width;
            Style = style;
        }

        public readonly uint Width;

        public readonly ulong Style;
    }
}