//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        public static S create<S,T>(uint count)
            where S : ISeq<S,T>, new()
                => new S().Alloc(count);
    }
}