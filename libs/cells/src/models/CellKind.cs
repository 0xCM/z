//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = NativeTypeWidth;

    /// <summary>
    /// Defines cell data type classifiers
    /// </summary>
    public enum CellKind : ushort
    {
        None,

        Cell8 = W.W8,

        Cell16 = W.W16,

        Cell32 = W.W32,

        Cell64 = W.W64,

        Cell128 = W.W128,

        Cell256 = W.W256,

        Cell512 = W.W512
    }
}