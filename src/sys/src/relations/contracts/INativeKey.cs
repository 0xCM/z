//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INativeKey : IKeyed
    {
        new ReadOnlySpan<byte> Key {get;}

        string IExpr.Format()
            => string.Join(' ', Key.Map(x => x.FormatHex()));
            
        bool INullity.IsEmpty
            => Key.IsEmpty;

        bool INullity.IsNonEmpty
            => !Key.IsEmpty;

        dynamic IKeyed.Key  
            => Key.ToArray();
    }

    [Free]
    public interface INativeKey<K> : INativeKey, IKeyed<K>
       where K : unmanaged, IEquatable<K>, IComparable<K>
    {
       new K Key {get;}

       K IKeyed<K>.Key
           => Key;

       ReadOnlySpan<byte> INativeKey.Key
           => sys.bytes(Key);
    }
}