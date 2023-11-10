//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedDisasm
{
    [MethodImpl(Inline), Op]
    public static IXedDisasmBuffer buffer(FilePath src)
        => new XedDisasmBuffer(src);

    [MethodImpl(Inline)]
    public static IXedDisasmFlow flow()
        => new XedDisasmFlow();
}