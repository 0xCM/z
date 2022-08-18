//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CpuCore
    {
        public uint Number {get;}

        public CpuCore(uint id)
        {
            Number  = id;
        }
    }

    public class CpuCore<T> : CpuCore
        where T : unmanaged
    {
        public CpuCore(uint id)
            : base(id)
        {

        }
    }
}