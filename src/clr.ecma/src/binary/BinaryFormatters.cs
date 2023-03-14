//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class BinaryFormatters
    {                    
        public static void verify<T>(T input, Span<byte> dst)
            where T : IEquatable<T>
        {
            dst.Clear();
            var a = encode(input, dst);
            var b = decode(dst,  out T output);
            Require.equal(a,b);
            if(!a.Equals(b))
                @throw($"{text.squote(input) != text.squote(output)}");
        }

        public static uint encode<T>(T src, uint offset, Span<byte> dst)
            => formatter<T>().Encode(src, offset, dst);

        public static uint encode<T>(T src, Span<byte> dst)
            => formatter<T>().Encode(src, 0, dst);

        public static uint decode<T>(ReadOnlySpan<byte> src, uint offset, out T dst)
            => formatter<T>().Decode(src, offset, out dst);

        public static uint decode<T>(ReadOnlySpan<byte> src, out T dst)
            => formatter<T>().Decode(src, 0, out dst);

        static Dictionary<Type,IBinaryFormatter> Formatters;

        static IBinaryFormatter<T> formatter<T>()
        {
            if(Formatters.TryGetValue(typeof(T), out var formatter))
            {
                return (IBinaryFormatter<T>)formatter;
            }
            else
            {
                return @throw<IBinaryFormatter<T>>($"Formatter for {typeof(T)} not found");
            }
        }

        public static ReadOnlySeq<IBinaryFormatter> discover()
        {
            var types = Assembly.GetExecutingAssembly().Types().Concrete().Realize<IBinaryFormatter>();
            return types.Select(x => (IBinaryFormatter)Activator.CreateInstance(x));
        }

        static BinaryFormatters()
        {
            Formatters = new();
            var formatters = discover();
            iter(formatters, formatter => {
                iter(formatter.SupportedTypes, t => Formatters[t]  = formatter);                
            });
        }

        sealed class UInt8Formatter : UnmanagedFormatter<byte> {}
        sealed class UInt16Formatter : UnmanagedFormatter<ushort> {}
        sealed class UInt32Formatter : UnmanagedFormatter<uint> {}
        sealed class UInt64Formatter : UnmanagedFormatter<ulong> {}

        sealed class Int8Formatter : UnmanagedFormatter<sbyte> {}
        sealed class Int16Formatter : UnmanagedFormatter<short> {}
        sealed class Int32Formatter : UnmanagedFormatter<int> {}
        sealed class Int64Formatter : UnmanagedFormatter<long> {}

        sealed class GuidFormatter : UnmanagedFormatter<Guid> {}

        sealed class DateTimeFormatter : UnmanagedFormatter<DateTime> {}

        sealed class DateTimeOffsetFormatter : UnmanagedFormatter<DateTimeOffset> {}

        class StringFormatter : BinaryFormatter<string>
        {            
            public override uint Encode(string src, uint offset, Span<byte> dst)
            {                
                var length = (uint)TextEncoders.utf8().Encode(src, slice(dst,32));
                seek32(dst,0) = length;
                seek(dst, 4 + length + 1) = 0;
                return 4 + length + 1;
            }

            public override uint Decode(ReadOnlySpan<byte> src, uint offset, out string dst)
            {
                var data = slice(src, offset);
                var length = u32(data);
                TextEncoders.utf8().Decode(slice(data,4), out dst);
                return 4 + length + 1;
            }
        }
   }
}