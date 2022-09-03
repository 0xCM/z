//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = ApiSigs;

    public sealed record class ApiSig : IEquatable<ApiSig>
    {
        public readonly ApiClass Class;

        public Index<Type> Components {get;}

        [MethodImpl(Inline)]
        public ApiSig(Index<Type> components)
        {
            Class = ApiClass.Empty;
            Components = components;
        }

        [MethodImpl(Inline)]
        public ApiSig(ApiClass @class, Index<Type> components)
        {
            Class = @class;
            Components = components;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public bool Equals(ApiSig src)
            => api.eq(this, src);

        public override int GetHashCode()
            => (int)api.hash(this);
    }
}