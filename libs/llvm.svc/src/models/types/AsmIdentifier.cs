//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [StructLayout(StructLayout, Pack=1), Record(TableId)]
    public readonly record struct AsmIdentifier : IListItem<AsmIdentifier,ushort,asci32>
    {
        public const string TableId = "llvm.asm.AsmId";

        /// <summary>
        /// The instruction id, in-synch with tablegen output
        /// </summary>
        public readonly ushort Id;

        /// <summary>
        /// The identified instruction name
        /// </summary>
        public readonly asci32 Name;

        [MethodImpl(Inline)]
        public AsmIdentifier(ushort id, asci32 name)
        {
            Id = id;
            Name = name;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Id;
        }

        ushort IListItem<ushort, asci32>.Key 
            => Id;

        asci32 IListItem<asci32>.Value 
            => Name;

        public string Format()
            => string.Format("{0:D5} {1}", Id, Name);

        public override string ToString()
            => Format();

        public bool Equals(AsmIdentifier src)
            => Id == src.Id && Name.Equals(src.Name);

        [MethodImpl(Inline)]
        public int CompareTo(AsmIdentifier src)
            => Id.CompareTo(src.Id);

        public override int GetHashCode()
            => Hash;
    }
}