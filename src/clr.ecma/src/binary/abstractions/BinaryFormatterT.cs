//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class BinaryFormatter<T> : BinaryFormatter, IBinaryFormatter<T>
    {
        public abstract uint Decode(ReadOnlySpan<byte> src, uint offset, out T dst);

        public abstract uint Encode(T src, uint offset, Span<byte> dst);

        public override uint Decode(ReadOnlySpan<byte> src, uint offset, out object dst)
        {
            var consumed = Decode(src, offset, out T _dst);
            dst = _dst;
            return consumed;
        }

        public override uint Encode(object src, uint offset, Span<byte> dst)
            => Encode((T)src, offset, dst);        

        public override ReadOnlySpan<Type> SupportedTypes 
            => _SupportedTypes;

        static readonly Type[] _SupportedTypes = sys.array<Type>(typeof(T));
    }
}