//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RenderWidthAttribute : Attribute
    {
        public RenderWidthAttribute(uint width)
        {
            Width = width;
        }

        public readonly uint Width;
    }
}