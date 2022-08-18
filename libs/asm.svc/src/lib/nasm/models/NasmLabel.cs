//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NasmLabel
    {
        public uint LineNumber {get;}

        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public NasmLabel(uint line, Identifier name)
        {
            LineNumber = line;
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public static NasmLabel Empty
        {
            [MethodImpl(Inline)]
            get => new NasmLabel(0,Identifier.Empty);
        }
    }
}