//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    public abstract record class Uri<U,S> : IUri<S>
        where U : Uri<U,S>, new()
        where S : unmanaged, IUriScheme        
    {
        protected System.Uri Data;

        public readonly S Scheme = default;

        string Text;

        Hash32 _Hash;

        protected Uri()
        {
            Data = new (EmptyName);
            Text = EmptyName;
            _Hash = 0;
        }

        protected Uri(System.Uri data)
        {
            Data = data;
            Text = data.ToString();
            _Hash = sys.hash(Text);
        }

        protected Uri(string data)
        {
            Data = new (data);
            Text = data;
            _Hash = sys.hash(Text);
        }

        S IUri<S>.Scheme 
            => Scheme;

        public static U parse(string src)
        {
            var dst = new U();
            dst.Data = new (src);
            dst._Hash = sys.hash(src);
            dst.Text = src;
            return dst;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => _Hash;
        }
        
        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Text == EmptyName;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public override int GetHashCode()
            => Hash;

        public virtual string Format()        
            => Text;

        public override string ToString()
            => Format();

        public virtual bool Equals(Uri<U,S> src)
            => Data == src.Data;

        const string EmptyName = "dev://null";
        
        public static U Empty => parse(EmptyName);
    }
}