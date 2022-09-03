//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class VK
    {
        /// <summary>
        /// Specifies the 256-bit vector type classifier
        /// </summary>
        public static Vec256Type v256
            => default;

        /// <summary>
        /// Reifies a cell-parametric 256-bit vector kind
        /// </summary>
        public static Vec256Kind<T> vk256<T>()
            where T : unmanaged
                => default;
    }
}