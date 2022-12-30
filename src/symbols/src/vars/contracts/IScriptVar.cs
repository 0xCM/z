//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IScriptVar<T>
        where T : unmanaged, IComparable<T>, IEquatable<T>
    {
        bool IsFenced {get;}

        Fence<T> Fence {get;}

        T Prefix {get;}

        bool IsPrefixed {get;}

        bool IsPrefixedFence
            => IsFenced && IsPrefixed;

        ScriptVarClass Class {get;}
    }
}