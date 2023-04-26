//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class BinaryFormat<F> : FileFormat<F>
        where F : BinaryFormat<F>, new()
    {
        protected BinaryFormat(string name)
            : base(name)
        {
        }
    }
}