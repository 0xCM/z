//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct RegNameSet : IIndex<AsmRegName>
    {
        public readonly text15 Name;

        readonly Index<AsmRegName> Data;

        [MethodImpl(Inline)]
        public RegNameSet(text15 name, AsmRegName[] src)
        {
            Name = name;
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref AsmRegName this[RegIndexCode i]
        {
            [MethodImpl(Inline)]
            get => ref Data[(byte)i];
        }

        public ref AsmRegName this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref AsmRegName this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public AsmRegName[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public Span<AsmRegName> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<AsmRegName> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }
        public string Format()
            => text.trim(Data.Map(x => x.Format())).Where(text.nonempty).Delimit().Format();

        public override string ToString()
            => Format();

        // [MethodImpl(Inline)]
        // public static implicit operator RegNameSet(AsmRegName[] src)
        //     => new RegNameSet(src);

        [MethodImpl(Inline)]
        public static implicit operator RegNameSet((string name, AsmRegName[] regs) src)
            => new RegNameSet(src.name, src.regs);

        public static RegNameSet Empty => new RegNameSet(text15.Empty, sys.empty<AsmRegName>());
    }
}