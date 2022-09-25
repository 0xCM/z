//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a field has been generated by the compiler
        /// </summary>
        /// <param name="f">The field to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsCompilerGenerated(this FieldInfo f)
            => f.Tagged<CompilerGeneratedAttribute>();
    }
}