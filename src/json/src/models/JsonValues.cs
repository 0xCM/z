//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static JsonTypes;

    [ApiHost]
    public partial class JsonValues
    {
        public record class JV : IJsonValue
        {
            public readonly dynamic Content;
            
            internal JV(dynamic value)
            {
                Content = value;                
            }

            public JV()
            {
                Content = @string.Empty;
            }

            public bool IsEmpty 
                => Json.empty(this);

            public IJsonType Type 
                => Json.type(this);

            dynamic IJsonValue.Content 
                => Content;

            public string Format()
                => Json.format(this);

            public static JV Empty => new();

        }

        public record class JV<V> : IJsonValue<V>
            where V : new()
        {
            public readonly V Content;

            public JV()
            {
                Content = new();
            }

            public JV(V value)
            {
                Content = value;
            }

            public IJsonType Type 
                => Json.type(this);

            public bool IsEmpty 
                => Json.empty(this);

            V IJsonValue<V>.Content 
                => Content;

            public string Format()
                => Json.format(this);

            [MethodImpl(Inline)]
            public static implicit operator JV<V>(V value)
                => new JV<V>(value);

            [MethodImpl(Inline)]
            public static implicit operator V(JV<V> src)
                => src.Content;

            [MethodImpl(Inline)]
            public static implicit operator JV(JV<V> src)
                => new JV(src.Content);

            public static JV<V> Empty => new();
        }

        public record class JV<T,V> : IJsonValue<V>
            where T : IJsonType,new()
            where V : new()
        {
            public readonly V Content;

            [MethodImpl(Inline)]
            public JV()
            {
                Content = new();
            }

            [MethodImpl(Inline)]
            public JV(V value)
            {
                Content = value;
            }

            public IJsonType Type 
                => Json.type(this);

            public bool IsEmpty 
                => Json.empty(this);

            V IJsonValue<V>.Content 
                => Content;

            public string Format()
                 => Json.format(this);

            [MethodImpl(Inline)]
            public static implicit operator JV(JV<T,V> src)
                => new JV(src.Content);

            [MethodImpl(Inline)]
            public static implicit operator JV<V>(JV<T,V> src)
                => new JV<V>(src.Content);

            [MethodImpl(Inline)]
            public static implicit operator JV<T,V>(V value)
                => new JV<T,V>(value);

            [MethodImpl(Inline)]
            public static implicit operator V(JV<T,V> src)
                => src.Content;

            public static JV<T,V> Empty => new ();
        }
    }
}