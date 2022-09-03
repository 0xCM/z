//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiIdentifier : IEquatable<ApiIdentifier>
    {
        public Cell128 Data {get;}

        [MethodImpl(Inline)]
        ApiIdentifier(Cell128 src)
            => Data = src;

        [MethodImpl(Inline)]
        public bool Equals(ApiIdentifier src)
            => Data.Equals(src.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is ApiIdentifier x && Equals(x);
   }
}