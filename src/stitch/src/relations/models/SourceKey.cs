//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        /// <summary>
        /// Identifies a domain-relative source
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct SourceKey
        {
            public readonly DomainKey Domain;

            public readonly uint Id;

            [MethodImpl(Inline)]
            public SourceKey(DomainKey d, uint id)
            {
                Domain = d;
                Id = id;
            }
        }
    }
}