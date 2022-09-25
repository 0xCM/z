//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RecordType : IRecordType
    {
        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public RecordType(Identifier name)
        {
            Name = name;
        }

        public string Format()
            => Name;
    }
}