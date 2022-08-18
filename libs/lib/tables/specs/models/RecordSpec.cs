//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RecordSpec : ITextual
    {
        public Identifier TypeName {get;}

        readonly Index<MemberFieldSpec> FieldSpecs;

        [MethodImpl(Inline)]
        public RecordSpec(Identifier name, MemberFieldSpec[] cells)
        {
            TypeName = name;
            FieldSpecs = cells;
        }

        public ReadOnlySpan<MemberFieldSpec> Fields
        {
            [MethodImpl(Inline)]
            get => FieldSpecs.View;
        }

        public Count FieldCount
        {
            [MethodImpl(Inline)]
            get => FieldSpecs.Count;
        }
        public string Format()
            => RecordBuilder.format(this);

        public override string ToString()
            => Format();
    }
}