//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class FileKind<K> : IFileKind<K>
        where K : FileKind<K>, new()
    {
        public static readonly K Descriptor = new();

        K IFileKind<K>.Descriptor
            => Descriptor;        
    }
}