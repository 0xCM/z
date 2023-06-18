//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SFx
    {
        /// <summary>
        /// Instantiates a service operation host
        /// </summary>
        /// <param name="host">The hosting type</param>
        [MethodImpl(Inline), Op]
        public static IFunc fx(Type host)
            => (IFunc)Activator.CreateInstance(host);
    }
}