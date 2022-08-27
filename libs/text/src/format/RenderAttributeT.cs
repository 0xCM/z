//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RenderAttribute<T> : RenderAttribute
        where T : unmanaged
    {
        public RenderAttribute(uint width, T style)
            : base(width, sys.bw64(style))
        {

        }
    }
}