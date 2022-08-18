//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TextFormatters
    {
        public static TextFormatters Service => Instance;

        readonly struct Formatter : ITextFormatter<object>
        {
            public RenderDelegate<object> Delegate {get;}

            [MethodImpl(Inline)]
            public Formatter(RenderDelegate<object> f)
            {
                Delegate = f;
            }

            [MethodImpl(Inline)]
            public string Format(object src)
                => Delegate(src);
        }

        readonly struct Formatter<T> : ITextFormatter<T>
        {
            public RenderDelegate<T> Delegate {get;}

            [MethodImpl(Inline)]
            public Formatter(RenderDelegate<T> f)
            {
                Delegate = f;
            }

            [MethodImpl(Inline)]
            public string Format(T src)
                => Delegate(src);
        }

        [MethodImpl(Inline)]
        public string Format<T>(T src)
            => FirstOrDefault(typeof(T)).Format(src);

        [MethodImpl(Inline)]
        public string Format<K,T>(T src, K selector)
            where K : unmanaged
                => RefinedOrDefault(typeof(T), selector).Format(src);

        [MethodImpl(Inline)]
        static ulong key<K>(Type type, K selector)
            where K : unmanaged
        {
            var token = (uint)type.MetadataToken;
            var part = type.Assembly.Id();
            return (ulong)token | ((ulong)part << 32) | ((ulong)sys.@as<K,ushort>(selector) << 38);
        }

        [MethodImpl(Inline)]
        static string @default(object src)
            => src?.ToString();

        [MethodImpl(Inline)]
        public ITextFormatter RefinedOrDefault<K>(Type type, K selector)
            where K : unmanaged
        {
            if(Lookup.TryGetValue(key(type,selector), out var dst))
                return dst;
            else
                return new Formatter(@default);
        }

        [MethodImpl(Inline)]
        public ITextFormatter FirstOrDefault(Type type)
        {
            if(Lookup.TryGetValue(key(type,(ushort)0), out var dst))
                return dst;
            else
                return new Formatter(@default);
        }

        [MethodImpl(Inline)]
        public bool Register<K,T>(K selector, ITextFormatter<T> formatter)
            where K : unmanaged
            => Lookup.TryAdd(key(typeof(T),selector), formatter);

        [MethodImpl(Inline)]
        public bool Register<K,T>(K selector, RenderDelegate<T> formatter)
            where K : unmanaged
                => Lookup.TryAdd(key(typeof(T),selector), new Formatter<T>(formatter));

        [MethodImpl(Inline)]
        public bool Register<K>(Type type, K selector, RenderDelegate<object> formatter)
            where K : unmanaged
                => Lookup.TryAdd(key(type,selector), new Formatter(formatter));

        ConcurrentDictionary<ulong, ITextFormatter> Lookup;

        TextFormatters()
        {
            Lookup = new();
        }

        static TextFormatters Instance;

        static TextFormatters()
        {
            Instance = new();
        }
    }
}