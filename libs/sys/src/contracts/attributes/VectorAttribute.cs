//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Applied to a user-defined type to identify it as an intrinsic vector (or, rather, should be treated/classified as one)
    /// </summary>
    public class VectorAttribute : WidthAttribute
    {
        public VectorAttribute(NativeTypeWidth width)
            : base(width)
        {
        }
    }
}