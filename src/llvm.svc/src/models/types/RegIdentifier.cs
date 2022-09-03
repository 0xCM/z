//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [StructLayout(StructLayout, Pack=1), Record(TableId)]
    public readonly record struct RegIdentifier : IListItem<RegIdentifier,ushort,asci16>
    {
        public const string TableId = "llvm.asm.RegId";

        /// <summary>
        /// The instruction id, in-synch with tablegen output
        /// </summary>
        public readonly ushort Id;

        /// <summary>
        /// The name of the identified register
        /// </summary>
        public readonly asci16 Name;

        [MethodImpl(Inline)]
        public RegIdentifier(ushort id, asci16 name)
        {
            Id = id;
            Name = name;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Id;
        }

        ushort IListItem<ushort, asci16>.Key 
            => Id;

        asci16 IListItem<asci16>.Value 
            => Name;

        public override int GetHashCode()
            => Hash;

        public string Format()
            => string.Format("{0:D5} {1}", Id, Name);

        public override string ToString()
            => Format();

        public bool Equals(RegIdentifier src)
            => Id == src.Id && Name == src.Name;

        [MethodImpl(Inline)]
        public int CompareTo(RegIdentifier src)
            => Id.CompareTo(src.Id);
    }
}