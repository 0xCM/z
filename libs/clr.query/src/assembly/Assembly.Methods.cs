//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects the methods from an assembly that satisfy a specified predicate
        /// </summary>
        /// <param name="src">The source assembly</param>
        /// <param name="pred">The adjudicating predicate</param>
        [Op]
        public static MethodInfo[] Methods(this Assembly src)
            => src.Types().Methods();

        /// <summary>
        /// Selects the methods from an assembly that satisfy a specified predicate
        /// </summary>
        /// <param name="src">The source assembly</param>
        /// <param name="pred">The adjudicating predicate</param>
        [Op]
        public static MethodInfo[] Methods(this Assembly src, Func<MethodInfo,bool> pred)
            => src.Methods().Where(pred);
    }
}