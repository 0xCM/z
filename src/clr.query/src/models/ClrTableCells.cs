//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ClrTableCells : Seq<ClrTableCells,ClrTableCell>
    {
        public ClrTableCells()
        {

        }

        [MethodImpl(Inline)]
        public ClrTableCells(ClrTableCell[] src)
            : base(src)
        {
        }


        [MethodImpl(Inline)]
        public string FormatFieldValue<T>(int index, T value)
            => Data[index].Format(value);

        [MethodImpl(Inline)]
        public static implicit operator ClrTableCells(ClrTableCell[] src)
            => new ClrTableCells(src);
    }
}