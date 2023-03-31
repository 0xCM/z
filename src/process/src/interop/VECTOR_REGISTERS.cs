//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe struct VECTOR_REGISTERS
    {
        fixed ulong Data[52];

        public override string ToString()
        {
            var cells = recover<Vector128<ulong>>(sys.bytes(this));
            var dst = text.emitter();
            for(var i=0; i<cells.Length; i++)
            {
                dst.AppendLine(skip(cells,i).FormatHex());
            }
            return dst.Emit();
        }
    }
}