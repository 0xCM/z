
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IUnmanaged : ISized, IValue
    {

    }

    /// <summary>
    /// Characterizes an unmanaged value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUnmanaged<T> : IUnmanaged, IValue<T>
        where T : unmanaged
    {
        ByteSize ISized.ByteCount
            => Sized.size<T>();
    }
}