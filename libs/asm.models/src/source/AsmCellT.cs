//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AsmCell<T> : IAsmSourcePart
    {
        /// <summary>
        /// The content origin
        /// </summary>
        public readonly CellIndex<uint> Location;

        public readonly AsmCellKind PartKind;

        public T Content {get;}

        AsmCellKind IAsmSourcePart.PartKind
            => PartKind;

        [MethodImpl(Inline)]
        public AsmCell(CellIndex<uint> loc, AsmCellKind kind, T data)
        {
            Location = loc;
            Content = data;
            PartKind = kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => PartKind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => PartKind != 0;
        }

        public string Format()
            => Content == null ? EmptyString : Content.ToString();

        public override string ToString()
            => Format();
    }
}