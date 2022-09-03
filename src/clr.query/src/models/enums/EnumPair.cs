//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures name-corellated literals values
    /// </summary>
    public readonly struct EnumPair<E1,E2>
        where E1: unmanaged, Enum
        where E2: unmanaged, Enum
    {
        /// <summary>
        /// The common name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The first enum value
        /// </summary>
        public readonly E1 First;

        /// <summary>
        /// The second enum value
        /// </summary>
        public readonly E2 Second;

        [MethodImpl(Inline)]
        public EnumPair(string name, E1 first, E2 second)
        {
            Name = name;
            First = first;
            Second = second;
        }
    }
}
