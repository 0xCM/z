//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class ClrQuery
    {
        /// <summary>
        /// Determines the <see cref='Z0.PrimalKind'/> of a specified type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Op]
        public static PrimalKind ClrPrimitiveKind(this Type t)
            => PrimalBits.kind(t);

        [Op]
        public static Type[] Classes(this Assembly a)
            => a.Types().Classes();

        [Op]
        public static Type[] Classes(this Assembly a, string name)
            => a.Classes().Where(c => c.Name == name);

        [Op]
        public static string[] DebugFlags(this Assembly src)
            => src.GetCustomAttributes<DebuggableAttribute>().Select(a => a.DebuggingFlags.ToString()).Array();
    }
}