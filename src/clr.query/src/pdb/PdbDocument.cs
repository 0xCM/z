//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.DiaSymReader;

    public readonly struct PdbDocument : IEquatable<PdbDocument>
    {
        public readonly string Name;

        public readonly Guid Type;

        readonly ISymUnmanagedDocument Unmanaged;

        [MethodImpl(Inline)]
        public PdbDocument(ISymUnmanagedDocument doc, string name, Guid type)
        {
            Unmanaged = doc;
            Name = name;
            Type = type;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(Name);
        }

        public FileUri Path
        {
            [MethodImpl(Inline)]
            get => new(Name);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Name;

        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(PdbDocument src)
            => text.equals(Name,src.Name) && Type == src.Type;

        public override bool Equals(object src)
            => src is PdbDocument x && Equals(x);

        public static PdbDocument Empty => new PdbDocument(null,EmptyString,Guid.Empty);
    }
}