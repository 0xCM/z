//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [BinaryFormatter]
    public abstract class BinaryFormatter : IBinaryFormatter
    {
        public abstract uint Decode(ReadOnlySpan<byte> src, uint offset, out object dst);
        
        public abstract uint Encode(object src, uint offset, Span<byte> dst);

        public abstract ReadOnlySpan<Type> SupportedTypes {get;}
    }
}