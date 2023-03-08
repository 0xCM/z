//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextVar<T> : IVar<T>
        where T : unmanaged, IComparable<T>, IEquatable<T>
    {
        ScriptVarClass Class {get;}
    }

    public interface ITextVar : INullity, IVar<@string>
    {

        bool INullity.IsEmpty
            => sys.empty(Value());
    }
}