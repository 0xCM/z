//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        /// <summary>
        /// Identifies a domain-relative target
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TargetKey
        {
            public readonly DomainKey Domain;

            public readonly uint Id;

            [MethodImpl(Inline)]
            public TargetKey(DomainKey d, uint id)
            {
                Domain = d;
                Id = id;
            }
        }
    }
}