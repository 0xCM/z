//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class Lines
    {

        [MethodImpl(Inline)]
        public static LineSegment segment(LineNumber src, ushort min, ushort max)
            => new LineSegment(src,min,max);
    }
}