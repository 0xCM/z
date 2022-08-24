//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EndianKind<T>
        where T : struct, IEndianKind<T>
    {
        public EndianKind Id 
            => default(T).Id;
    }
}