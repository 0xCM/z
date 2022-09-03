//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DfaState<K>
        where K : unmanaged
    {
        /// <summary>
        /// The state position within a given string
        /// </summary>
        public readonly uint Key;

        public readonly K Symbol;

        [MethodImpl(Inline)]
        public DfaState(uint key, K b)
        {
            Key = key;
            Symbol = b;
        }

        public string Format()
            => Symbol.ToString();

        public override string ToString()
            => Format();
    }
}