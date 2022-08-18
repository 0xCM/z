//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataCalcs
    {
        public AsmIdentifiers CalcAsmIdentifiers(LlvmTargetName target)
        {
            const string BeginAsmIdMarker = "PHI	= 0,";
            const string HeaderKind = "InstInfo";
            var path = LlvmPaths.TableGenHeader(target,HeaderKind);
            var dst = AsmIdentifiers.Empty;
            if(path.Missing)
            {
                Error(FS.missing(path));
            }
            else
            {
                dst = LlvmIdentifiers.discover<ushort>(path,BeginAsmIdMarker).Map(x => new AsmIdentifier(x.Key, x.Value));
            }
            return dst;


            // var src = LlvmPaths.TableGenHeaders(target).Where(x => x.FileName == FS.file($"{target}.InstInfo", FileKind.H));
            // if(src.Count != 1)
            // {
            //     Error("Path not found");
            //     return llvm.AsmIdentifiers.Empty;
            // }
            // return LlvmIdentifiers.discover<ushort>(src[0],BeginAsmIdMarker).Map(x => new AsmIdentifier(x.Key, x.Value));
        }
    }
}