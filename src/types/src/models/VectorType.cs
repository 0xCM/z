//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class VectorType : IVectorType
    {
        public Identifier Name {get;}

        public ScalarType CellType {get;}

        public uint CellCount {get;}

        public ulong Kind {get;}

        public BitWidth ContentWidth
            => CellType.ContentWidth*CellCount;

        public BitWidth StorageWidth
            => CellType.StorageWidth*CellCount;

        [MethodImpl(Inline)]
        internal VectorType(Identifier name, ScalarType cellkind, uint n)
        {
            Name = name;
            CellType = cellkind;
            CellCount = n;
            Kind = 0;
        }

        public string Format()
            => TypeSyntax.v(CellCount, CellType.Format());

        public override string ToString()
            => Format();
    }
}