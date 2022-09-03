//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public sealed class AsmIdentifiers : ConstLookup<Identifier,AsmIdentifier>
    {
        public AsmIdentifiers(AsmIdentifier[] src)
            : base(src.Map(x => ((Identifier)x.Name.Format(), x)).ToDictionary())
        {

        }

        public ushort AsmId(string name)
        {
            if(Find(name, out var value))
            {
                return value.Id;
            }
            else
                return 0xFFFF;
        }

        public ItemList<AsmIdentifier, ushort,asci32> ToItemList()
            => new ItemList<AsmIdentifier,ushort,asci32>("AsmId", MapValues(x => new AsmIdentifier(x.Id, x.Name)));

        public static implicit operator AsmIdentifiers(AsmIdentifier[] src)
            => new AsmIdentifiers(src);

        public static new AsmIdentifiers Empty => new(sys.empty<AsmIdentifier>());
    }
}