//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        /// <summary>
        /// For a type that encodes a natural number, returns the corresponding value; otherwise, returns none
        /// </summary>
        /// <param name="t">The type to examine</param>
        public static Option<ulong> NatValue(this Type t)
            => t.IsTypeNat() ? ((ITypeNat)Activator.CreateInstance(t)).NatValue : default;

        /// <summary>
        /// Returns the type's natural reification if it exists; otherwise, returns the 0 reification
        /// </summary>
        /// <param name="t">The type to examine</param>
        public static ITypeNat TypeNatural(this Type t)
            => t.IsTypeNat() ? (ITypeNat)Activator.CreateInstance(t) : default(N0);
    }
}