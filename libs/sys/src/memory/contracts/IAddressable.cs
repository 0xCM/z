//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a value that is located via a memory address
    /// </summary>
    [Free]
    public interface IAddressable : ILocatable<MemoryAddress>
    {
        MemoryAddress Address {get;}

        string IExpr.Format()
            => Address.Format();

        MemoryAddress ILocatable<MemoryAddress>.Location
            => Address;
    }
}