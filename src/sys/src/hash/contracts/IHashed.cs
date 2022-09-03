//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a hash code provider
    /// </summary>
    [Free]
    public interface IHashed
    {
        /// <summary>
        /// The hash code as an unsigned 32-bit integer
        /// </summary>
        Hash32 Hash {get;}

        int GetHashCode()
            => Hash;
    }

    [Free]
    public interface IHashed<C> : IHashed
        where C : unmanaged, IHashCode
    {
        new C Hash {get;}
    }

    // public interface IHashed<H,T>
    //     where H : IHashed<H,T>
    //     where T : unmanaged, IHashCode<T>
    // {

    // }
}