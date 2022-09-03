//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataCalcs
    {
        public RegIdentifiers CalcRegIdentifiers(LlvmTargetName target)
        {
            const string BeginRegsMarker = "NoRegister,";
            var src = LlvmPaths.TableGenHeaders(target).Where(x => x.FileName == FS.file($"{target}.Regs", FileKind.H));
            if(src.Count != 1)
            {
                Error("Path not found");
                return llvm.RegIdentifiers.Empty;
            }
            return LlvmIdentifiers.discover<ushort>(src[0],BeginRegsMarker).Map(x => new RegIdentifier(x.Key, x.Value));
        }

    }
}