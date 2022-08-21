//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a segment reference
    /// </summary>
    [Free]
    public interface IMemorySegment : IExpr, IHashed
    {
        MemoryAddress BaseAddress {get;}

        uint Length  {get;}

        bool INullity.IsEmpty
            => Length == 0;

        ref byte Cell(int index);

        ref byte this[int index]
            => ref Cell(index);
    }
}