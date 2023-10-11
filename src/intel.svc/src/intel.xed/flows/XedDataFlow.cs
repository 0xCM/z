//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static sys;

public partial class XedFlows : WfSvc<XedFlows>
{
    public static ref readonly Index<AsmBroadcast> BroadcastDefs
    {
        [MethodImpl(Inline), Op]
        get => ref _BroadcastDefs;
    }


    void Emit(ReadOnlySpan<FieldImport> src)
        => Channel.TableEmit(src, XedPaths.Imports().Table<FieldImport>());

    static readonly Index<AsmBroadcast> _BroadcastDefs = Xed.broadcasts(Symbols.kinds<BroadcastKind>());
}
