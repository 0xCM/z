//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RecordType<T> : IRecordType<T>
        where T : struct
    {
        public Identifier Name
            => Tables.identify<T>().Format();

        public string Format()
            => Name;

        public static implicit operator RecordType(RecordType<T> src)
            => new RecordType(src.Name);
    }
}