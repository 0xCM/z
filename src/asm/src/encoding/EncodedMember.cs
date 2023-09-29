//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
public struct EncodedMember : IComparable<EncodedMember>
{
    const string TableId = "members.encoded";

    public const byte FieldCount = 11;

    [Render(16)]
    public Hex64 Id;

    [Render(16)]
    public MemoryAddress EntryAddress;

    [Render(16)]
    public MemoryAddress EntryRebase;

    [Render(16)]
    public MemoryAddress TargetAddress;

    [Render(16)]
    public MemoryAddress TargetRebase;

    [Render(24)]
    public @string StubAsm;

    [Render(10)]
    public Disp32 Disp;

    [Render(8)]
    public ushort CodeSize;

    [Render(24)]
    public @string Host;

    [Render(120)]
    public @string Sig;

    [Render(1)]
    public @string Uri;

    [MethodImpl(Inline)]
    public int CompareTo(EncodedMember src)
        => EntryAddress.CompareTo(src.EntryAddress);

    public static IComparer<EncodedMember> comparer(CmpKind kind)
        => new Cmp(kind);

    public enum CmpKind : byte
    {
        Entry,

        Target,
    }

    readonly struct Cmp : IComparer<EncodedMember>
    {
        readonly CmpKind Mode;

        [MethodImpl(Inline)]
        public Cmp(CmpKind mode)
        {
            Mode = mode;
        }

        [MethodImpl(Inline)]
        public int Compare(EncodedMember x, EncodedMember y)
        {
            if(Mode == CmpKind.Entry)
                return x.EntryAddress.CompareTo(y.EntryAddress);
            else
                return x.TargetAddress.CompareTo(y.TargetAddress);
        }
    }
}
