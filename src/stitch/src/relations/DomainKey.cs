//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        /// <summary>
        /// Defines a key over a kind-stratified domain
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct DomainKey
        {
            public readonly Domain Domain;

            public readonly uint Id;

            [MethodImpl(Inline)]
            public DomainKey(Domain domain, uint id)
            {
                Id = id;
                Domain = domain;
            }
        }
    }
}