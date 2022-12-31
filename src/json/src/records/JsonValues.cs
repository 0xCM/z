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
        public static JV<Record,T> record<T>(in T src)
            where T : new()
                => src;

        public static JV<Records,Seq<T>> records<T>(Seq<T> src)
            where T : new()
                => src;

        [Op]
        public static JV<I8,sbyte> i8(sbyte value)
            => value;

        [Op]
        public static JV<U8,byte> u8(byte value)
            => value;

        [Op]
        public static JV<U8,short> i16(short value)
            => value;

        [Op]
        public static JV<U8,ushort> u16(ushort value)
            => value;

        public static JV<Text,JsonText> text(string value)
            => new JsonText(value);

        public record class JV
        {
            public readonly dynamic Value;
            
            internal JV(dynamic value)
            {
                Value = value;                
            }

            public JV()
            {
                Value = @string.Empty;
            }

            public static JV Empty => new();
        }

        public record class JV<V>
            where V : new()
        {
            public readonly V Value;

            public JV()
            {
                Value = new();
            }

            public JV(V value)
            {
                Value = value;
            }

            public static JV<V> Empty => new();

            [MethodImpl(Inline)]
            public static implicit operator JV<V>(V value)
                => new JV<V>(value);

            [MethodImpl(Inline)]
            public static implicit operator V(JV<V> src)
                => src.Value;

            public static implicit operator JV(JV<V> src)
                => new JV(src.Value);
        }

        public record class JV<T,V>
            where T : IJsonType,new()
            where V : new()
        {
            public readonly V Value;

            [MethodImpl(Inline)]
            public JV()
            {
                Value = new();
            }

            [MethodImpl(Inline)]
            public JV(V value)
            {
                Value = value;
            }

            public static JV<T,V> Empty => new ();

            [MethodImpl(Inline)]
            public static implicit operator JV(JV<T,V> src)
                => new JV(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator JV<V>(JV<T,V> src)
                => new JV<V>(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator JV<T,V>(V value)
                => new JV<T,V>(value);

            [MethodImpl(Inline)]
            public static implicit operator V(JV<T,V> src)
                => src.Value;
        }
    }
}