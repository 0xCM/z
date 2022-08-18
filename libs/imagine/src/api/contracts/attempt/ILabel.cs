//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes type that defines a Label facet
    /// </summary>
    public interface ILabel : IContented<string>, ITextual
    {
        string ITextual.Format()
            => Content;
    }

    /// <summary>
    /// Characterizes a kinded label
    /// </summary>
    /// <typeparam name="H">The reifing type</typeparam>
    /// <typeparam name="K">The kind type</typeparam>
    public interface ILabel<K> : ILabel, IKinded<K>
        where K : unmanaged
    {
    }
}