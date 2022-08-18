//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class XTend
    {
        /// <summary>
        /// Identifies a method
        /// </summary>
        /// <param name="m">The method to identify</param>
        public static OpIdentity Identify(this MethodInfo m)
            => ApiIdentity.identify(m);
    }
}