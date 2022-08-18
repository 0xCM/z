//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Determines the variance of a parameter
        /// </summary>
        /// <param name="src">The source parameter</param>
        [MethodImpl(Inline), Op]
        public static ClrParamModifierKind RefKind(this ParameterInfo src)
            => src.IsIn
            ? ClrParamModifierKind.In  : src.IsOut
            ? ClrParamModifierKind.Out : src.ParameterType.IsByRef
            ? ClrParamModifierKind.Ref : ClrParamModifierKind.None;

        [MethodImpl(Inline), Op]
        public static string Keyword(this ClrParamModifierKind src)
            => src switch{
                ClrParamModifierKind.In => "in",
                ClrParamModifierKind.Out => "out",
                ClrParamModifierKind.Ref => "ref",
                _ => ""
            };

        [MethodImpl(Inline), Op]
        public static string Format(this ClrParamModifierKind src)
            => src != 0 ? ('~' + src.Keyword()) : string.Empty;
    }
}