//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    public abstract class Distribution<S,T> : IDistribution<T>
        where T : unmanaged
        where S : IDistributionSpec<T>
    {
        protected IPolyrand Polyrand {get;}

        public S Spec {get;}

        public int BufferLength
            => 0;

        public DistributionKind DistKind
            => Spec.DistKind;

        protected Distribution(IPolyrand random, S spec)
        {
            Polyrand = random;
            Spec =spec;
        }

        public abstract IEnumerable<T> Sample();

        public IEnumerator<T> GetEnumerator()
            => Sample().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public T Next()
            => Sample().First();

        public IEnumerable<T> Next(int count)
            => Sample().Take(count);
    }
}