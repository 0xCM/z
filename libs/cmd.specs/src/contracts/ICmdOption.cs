//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdOption : IExpr, INullity
    {
        @string Name {get;}

        @string Value {get;}

        bool INullity.IsEmpty
            => Name.IsEmpty;

        bool INullity.IsNonEmpty
            => Name.IsNonEmpty;

        string IExpr.Format()
            => Value.IsEmpty ? Name.Format() : string.Format("{0}={1}", Name, Value);
    }
}