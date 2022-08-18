//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a type that identifies as a natural number
    /// </summary>
    public interface INaturalized
    {
        ulong Natural {get;}
    }

    /// <summary>
    /// Characterizes a type with which a number of parametric type is associated
    /// </summary>
    /// <typeparam name="N">The natural number type</typeparam>
    public interface INaturalized<N> : INaturalized
        where N : unmanaged, ITypeNat
    {
        ulong INaturalized.Natural 
            => default(N).NatValue;        
    }
}