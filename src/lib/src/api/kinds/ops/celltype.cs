//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    partial class VK
    {
        /// <summary>
        /// Returns the clr cell type of a vector of specified kind
        /// </summary>
        /// <param name="kind">The vector kind</param>
        [Op]
        public static Type celltype(NativeVectorKind kind)
        {
            if(test(kind, z8i))
                return typeof(sbyte);
            else if(test(kind, z8))
                return typeof(byte);
            else if(test(kind, z16i))
                return typeof(short);
            else if(test(kind, z16))
                return typeof(ushort);
            else if(test(kind, z32i))
                return typeof(int);
            else if(test(kind, z32))
                return typeof(uint);
            else if(test(kind, z64i))
                return typeof(long);
            else if(test(kind, z64))
                return typeof(ulong);
            else if(test(kind, z32f))
                return typeof(float);
            else if(test(kind, z64f))
                return typeof(double);
            else
                return typeof(void);
        }
    }
}