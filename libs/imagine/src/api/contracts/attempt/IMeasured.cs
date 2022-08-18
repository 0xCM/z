//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a type that exhibits a notion of finite length
    /// </summary>
    [Free]
    public interface IMeasured : ICounted
    {
        int Length {get;}

        uint ICounted.Count
            => (uint)Length;
    }

    /// <summary>
    /// Characterizes a reified type that  exhibits a notion of length
    /// </summary>
    [Free]
    public interface IMeasured<T> : IMeasured, ICounted<T>
        where T : unmanaged
    {
        int IMeasured.Length
            => Unsafe.As<T,int>(ref Unsafe.AsRef(Length));

        uint ICounted.Count
            => Unsafe.As<T,uint>(ref Unsafe.AsRef(Length));

        new T Length
            => Count;

        T ICounted<T>.Count
            => Length;
    }
}