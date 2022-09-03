//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static TypeNats;

    partial class NatRequire
    {
        /// <summary>
        /// Registers natural constraint failure
        /// </summary>
        /// <param name="name">The name of the constraint that failed</param>
        /// <param name="n">The subject value</param>
        /// <param name="raise">Specifies whether to raise an error</param>
        /// <typeparam name="K">The natural type for which a constraint failed</typeparam>
        [MethodImpl(Inline)]
        static bool failure<K>(string name, uint n, bool raise = true)
            where K : unmanaged, ITypeNat
        {
            if(raise)
                DemandException.Throw("eq", n, value<K>());
            return false;
        }

        /// <summary>
        /// Registers natural constraint failure
        /// </summary>
        /// <param name="name">The name of the constraint that failed</param>
        /// <param name="n">The subject value</param>
        /// <param name="raise">Specifies whether to raise an error</param>
        /// <typeparam name="K">The natural type for which a constraint failed</typeparam>
        [MethodImpl(Inline)]
        static bool failure<K>(string name, ulong n, bool raise = true)
            where K : unmanaged, ITypeNat
        {
            if(raise)
                DemandException.Throw("eq", n, value<K>());
            return false;
        }

        /// <summary>
        /// Registers a natural constraint failure
        /// </summary>
        /// <param name="name">The name of the constraint that failed</param>
        /// <param name="n">The subject value</param>
        /// <param name="raise">Specifies whether to raise an error</param>
        /// <typeparam name="K">The natural type for which a constraint failed</typeparam>
        /// <typeparam name="T">The subject type</typeparam>
        [MethodImpl(Inline)]
        static T failure<K,T>(string name, T n, bool raise = true)
            where K : unmanaged, ITypeNat
        {
            if(raise)
                DemandException.Throw("eq", n, value<K>());
            return n;
        }

        /// <summary>
        /// Registers a natural pair constraint failure
        /// </summary>
        /// <param name="name">The name of the constraint that failed</param>
        /// <param name="raise">Specifies whether to raise an error</param>
        /// <typeparam name="K1">The first natural type</typeparam>
        /// <typeparam name="K2">The second natural type</typeparam>
        [MethodImpl(Inline)]
        static bool failure<K1,K2>(string name, bool raise = true)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
        {
            if(raise)
                DemandException.Throw(name, TypeNats.pairval<K1,K2>());
            return false;
        }
    }
}