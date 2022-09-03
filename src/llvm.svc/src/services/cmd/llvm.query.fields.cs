//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/query/fields")]
        Outcome QueryDefFields(CmdArgs args)
        {
            var result = Outcome.Success;
            if(args.Count == 2)
            {
                result = DataParser.parse(arg(args,0).Value, out uint offset);
                if(result.Fail)
                    return result;

                result = DataParser.parse(arg(args,1).Value, out uint length);
                if(result.Fail)
                    return result;

                var formatter = Tables.formatter<RecordField>();
                var selected = slice(DataProvider.DefFields(LlvmTargetName.x86).View, offset, length);
                iter(selected, field => Row(formatter.Format(field)));
                TableEmit(selected, LlvmPaths.QueryOut($"llvm.defs.fields.{offset}-{offset + length}", FileKind.Csv));

            }
            return result;
        }
    }
}