//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CpuCore
    {
        public readonly uint Number;

        public CpuCore(uint id)
        {
            Number  = id;
        }

        public string Format()
            => string.Format("{0:D2}", Number);
        
        public override string ToString()
            => Format();
    }
}