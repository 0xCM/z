//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public struct AsmInstRef
{
    public Hex32 DocId;

    public uint DocSeq;

    public LineNumber Line;

    public Identifier AsmName;

    [MethodImpl(Inline)]
    public AsmInstRef(uint docid, uint seq, LineNumber line, Identifier name)
    {
        DocId = docid;
        DocSeq = seq;
        Line = line;
        AsmName = name;
    }

    public string Format()
        => string.Format("{0,-12} | {1,-8} | {2,-8} | {3}", DocId, DocSeq, Line, AsmName);

    public override string ToString()
        => Format();
}
