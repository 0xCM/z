//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public readonly struct EntityFieldSet : IIndex<RecordField>
    {
        public string EntityName {get;}

        readonly Index<RecordField> Data;

        [MethodImpl(Inline)]
        public EntityFieldSet(string name, RecordField[] src)
        {
            EntityName = name;
            Data = src;
        }

        public ReadOnlySpan<RecordField> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public RecordField[] Storage
        {
            get => Data;
        }
    }
}