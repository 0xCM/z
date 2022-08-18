//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class HashCodes
    {
        partial class Generic
        {
            /// <summary>
            /// Computes a combined calc code for a pair
            /// </summary>
            /// <typeparam name="T">The primitive type</typeparam>
            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static uint combine<T>(T x, T y)
                => hash_u(x,y);
        }
    }
}