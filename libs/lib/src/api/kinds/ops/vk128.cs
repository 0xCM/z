//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class VK
    {
        /// <summary>
        /// Specifies the 128-bit vector type classifier
        /// </summary>
        public static Vec128Type v128
            => default;

        /// <summary>
        /// Reifies a cell-parametric 128-bit vector kind
        /// </summary>
        public static Vec128Kind<T> vk128<T>()
            where T : unmanaged
                => default;
    }
}