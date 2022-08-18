//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ExprFormatters
    {
        [Op]
        public static string format(IVarValue var, char assign)
            => string.Format("{0}{1}{2}", var.VarName, assign, var.VarValue);

        [Formatter]
        public static string format(IVarValue var)
            => format(var, Chars.Eq);

        [Op]
        public static string format(VarContextKind vck, IVarValue var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.VarName), assign, var.VarValue);

        [Op]
        public static string format(VarContextKind vck, IVarValue var)
            => format(vck,var, Chars.Eq);

        [Op]
        internal static string format(VarContextKind vck, Name src)
            => string.Format(RpOps.pattern(vck), src);
    }
}