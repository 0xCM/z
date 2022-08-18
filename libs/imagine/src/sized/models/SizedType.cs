//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SizedType : ISizedType
    {
        [MethodImpl(Inline)]
        public static ByteSize untyped<T>(Size<T> src)
            where T : unmanaged
                => Sized.bw64(src.Measure);

        public virtual Identifier Name {get;}

        public Identifier Class {get;}

        public ulong Kind {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}

        public SizedType(string name, Identifier @class, ulong kind, BitWidth content, BitWidth storage)
        {
            Name = name;
            Class = @class;
            Kind = kind;
            ContentWidth = content;
            StorageWidth = storage;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public virtual string Format()
            => Name;


        public override string ToString()
            => Format();
    }
}