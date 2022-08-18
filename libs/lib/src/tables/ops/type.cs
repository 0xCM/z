//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        public RecordType<T> type<T>()
            where T : struct
                => default;

        [MethodImpl(Inline), Op]
        public RecordType type(Type src)
            => new RecordType(src.Name);
    }
}