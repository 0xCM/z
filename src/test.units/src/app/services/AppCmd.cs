//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class TestCmd : WfAppCmd<TestCmd>
    {
        [CmdOp("units/run")]
        Outcome RunUnits(CmdArgs args)
        {
            TestRunner.Run(sys.array(PartId.Lib, PartId.TestUnits));
            return true;
        }

        [CmdOp("bitmasks/check")]
        void Hello()
        {
            var src = BitMask.masks(typeof(BitMaskLiterals));
            var formatter = CsvTables.formatter<BitMaskLiterals>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var mask = ref src[i];
                Write(formatter.Format(mask));
                Write(mask.Text);
            }
        }
    }
}