//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes structured blocked functions
    /// </summary>
    [Free, SFx]
    public interface IBlockedFunc : IFunc
    {
        _OpIdentity IFunc.Id => _OpIdentity.Empty;
    }

    /// <summary>
    /// Characterizes identified SBF operations that are width-parametric
    /// </summary>
    /// <typeparam name="W">The width type</typeparam>
    [Free, SFx]
    public interface IBlockedFunc<W> : IBlockedFunc
        where W : unmanaged, ITypeWidth
    {

    }

    /// <summary>
    /// Characterizes identified SBF operations that are cell and width-parametric
    /// </summary>
    /// <typeparam name="W">The width type</typeparam>
    /// <typeparam name="T">The cell type</typeparam>
    [Free, SFx]
    public interface IBlockedFunc<W,T> : IBlockedFunc<W>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IBlockedFunc<W,S,T> : IBlockedFunc<W>
        where W : unmanaged, ITypeWidth
        where S : unmanaged
        where T : unmanaged
    {

    }
}