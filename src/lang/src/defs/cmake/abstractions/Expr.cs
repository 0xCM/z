//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using static CMake.Types;

    partial class CMake
    {
        public abstract record class Expr<V>
        {
            public abstract V Evaluate();
        }
    }
}