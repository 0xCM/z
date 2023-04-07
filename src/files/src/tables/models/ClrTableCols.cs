//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ClrTableCols : Seq<ClrTableCols,ClrTableCol>
    {
        public ClrTableCols()
        {

        }

        [MethodImpl(Inline)]
        public ClrTableCols(ClrTableCol[] src)
            : base(src)
        {
        }


        [MethodImpl(Inline)]
        public string FormatFieldValue<T>(int index, T value)
            => Data[index].Format(value);

        [MethodImpl(Inline)]
        public static implicit operator ClrTableCols(ClrTableCol[] src)
            => new ClrTableCols(src);
    }
}