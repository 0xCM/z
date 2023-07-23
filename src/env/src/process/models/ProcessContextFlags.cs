//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(StructLayout,Pack=1)]
public record struct ProcessContextFlags
{
    public bit EmitSummary;

    public bit EmitDetail;

    public bit EmitDump;

    public bit EmitHashes;

    public bit IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => EmitSummary | EmitDetail | EmitDump | EmitHashes;
    }

    public bit IsEmpty
    {
        [MethodImpl(Inline)]
        get => !IsNonEmpty;
    }

    public static ProcessContextFlags Empty
        => default;
}
