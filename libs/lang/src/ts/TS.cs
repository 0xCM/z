//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public partial class TS
    {    

        public interface IUnionType<U> : IType<U>
            where U : IUnionType<U>,new()
        {

        }
    }
}