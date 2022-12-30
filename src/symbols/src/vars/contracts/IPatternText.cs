//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a pararametric text block bound to an arbitrary number of variables
    /// </summary>
    public interface IPatternText : IExpr
    {
        TextBlock Pattern {get;}

        Seq<object> Vars {get;}

        uint VarCount
            => Vars.Count;

        bool INullity.IsEmpty
            => Pattern.IsEmpty;

        bool INullity.IsNonEmpty
            => Pattern.IsNonEmpty;
    }
}