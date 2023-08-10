//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public void ExportTokens(SymbolGroup group)
        {
            const string MemberPattern = "{0}:{1},";
            var indent = 0u;
            var emitter = text.emitter();
            group.EmitTypeLiterals(ref indent, emitter);
            group.EmitMembers(ref indent, emitter);
            Channel.FileEmit(emitter.Emit(), SdmPaths.Targets().Path(group.GroupName, FS.ext("ts")));
        }
    }
}