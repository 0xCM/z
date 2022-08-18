//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EmptyRecord : IRecord<EmptyRecord>
    {

    }

    public readonly struct EmptyRecord<T> : IRecord<EmptyRecord<T>>
    {
        public static implicit operator EmptyRecord(EmptyRecord<T> src)
            => default;

        public static implicit operator EmptyRecord<T>(T src)
            => default;
    }
}