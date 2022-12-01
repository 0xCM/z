//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    public readonly struct DocModels
    {
        public abstract class Doc
        {
            public uint LineCount {get; protected set;}
        }

        public abstract class Doc<K> : Doc
            where K : unmanaged, IEquatable<K>
        {
            public Doc(K[] src)
            {
                Data = src;
            }

            Index<K> Data;

            public ReadOnlySpan<K> Cells
            {
                [MethodImpl(Inline)]
                get => Data.View;
            }

            public DocReader<K> CreateReader()
                => new DocReader<K>(this);
        }
    }
}