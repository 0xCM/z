//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class HostCollection : Seq<HostCollection, CollectedHost>
    {
        public HostCollection()
        {

        }

        public HostCollection(CollectedHost[] src)
            : base(src)
        {
            
        }

        [MethodImpl(Inline)]
        public static implicit operator HostCollection(CollectedHost[] src)
            => new HostCollection(src);
    }
}