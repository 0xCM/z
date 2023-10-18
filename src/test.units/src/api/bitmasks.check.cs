//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class ApiOps
{
    [CmdOp("bitmasks/check")]
    void CheckBitmasks()
    {
        var src = BitMask.masks(typeof(BitMaskLiterals));
        var formatter = CsvTables.formatter<BitMaskLiterals>();
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var mask = ref src[i];
            Channel.Write(formatter.Format(mask));
            Channel.Write(mask.Text);
        }
    }
}
