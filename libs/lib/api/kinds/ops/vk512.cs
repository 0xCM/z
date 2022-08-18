//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class VK
    {
        /// <summary>
        /// Specifies the 512-bit vector type classifier
        /// </summary>
        public static Vec512Type v512
            => default;

        /// <summary>
        /// Reifies a cell-parametric 512-bit vector kind
        /// </summary>
        public static Vec512Kind<T> vk512<T>()
            where T : unmanaged
                => default;
    }
}