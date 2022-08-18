//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a structural function that is width-parametric
    /// </summary>
    /// <typeparam name="W">The width type</typeparam>
    [Free, SFx]
    public interface IFuncW<W> : IFunc
        where W : unmanaged, ITypeWidth
    {
        NativeTypeWidth TypeWidth
            => default(W).TypeWidth;
    }

    /// <summary>
    /// Characterizes a width-parametric and T-parameteric structural function
    /// </summary>
    /// <typeparam name="W">The width type</typeparam>
    /// <typeparam name="T">Unconstrained</typeparam>
    [Free, SFx]
    public interface IFuncWT<W,T> : IFuncW<W>
        where W : unmanaged, ITypeWidth
    {

    }

    [Free, SFx]
    public interface IFunc8<T> : IFuncW<W8>
        where T : unmanaged
    {


    }

    [Free, SFx]
    public interface IFunc16<T> : IFuncW<W16>
        where T : unmanaged
    {


    }

    [Free, SFx]
    public interface IFunc32<T> : IFuncW<W32>
        where T : unmanaged
    {


    }

    [Free, SFx]
    public interface IFunc64<T> : IFuncW<W64>
        where T : unmanaged
    {


    }

    [Free, SFx]
    public interface IFunc128<T> : IFuncW<W128>
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IFunc256<T> : IFuncW<W256>
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IFunc512<T> : IFuncW<W512>
        where T : unmanaged
    {
    }
}