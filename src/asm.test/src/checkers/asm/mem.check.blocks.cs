//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCheckCmd
    {
        [CmdOp("mem/check/blocks")]
        Outcome CheckBlockSize(CmdArgs args)
        {
            CheckTrimmedBlocks();
            CheckBlockPartitions();
            return true;
        }

        void CheckTrimmedBlocks()
        {
            var output = EmptyString;
            var input = ByteBlock4.Empty;

            input = 0xFF000000;
            output = Storage.trim(input).Format();

            input = 0xFF0000;
            output = Storage.trim(input).Format();

            input = 0xFF00;
            output = Storage.trim(input).Format();

            input = 0xFF;
            output = Storage.trim(input).Format();

            input = 0x0;
            output = Storage.trim(input).Format();
        }

        void CheckBlockPartitions()
        {
            var formatter = CsvTables.formatter<BlockPartition>();
            Write(formatter.FormatHeader());
            Write(formatter.Format(BlockPartition.calc(1024, 256, 11)));
            Write(formatter.Format(BlockPartition.calc(9591191, 256, 128)));
        }
    }
}