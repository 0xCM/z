//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Sized;

    public class SizedType<K> : ISizedType<K>
        where K : unmanaged
    {
        public Identifier Name {get;}

        public K Kind {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}

        public SizedType(string name, K kind, BitWidth content, BitWidth storage)
        {
            Name = name;
            Kind = kind;
            ContentWidth = content;
            StorageWidth = storage;
        }
        public string Format()
            => Name;

        public static implicit operator SizedType(SizedType<K> src)
            => new SizedType(src.Name, src.Kind.ToString(), bw64(src.Kind), src.ContentWidth, src.StorageWidth);
    }
}