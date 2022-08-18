//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Convenience accessor for the assembly's version
        /// </summary>
        /// <param name="a">The source assembly</param>
        [Op]
        public static Version AssemblyVersion(this Assembly a)
            => a.GetName().Version;
    }
}