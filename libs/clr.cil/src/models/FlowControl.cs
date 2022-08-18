//-----------------------------------------------------------------------------
// Copyright   :  Microsoft/DotNet Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cil
    {
        public enum FlowControl : byte
        {
            Branch = 0,

            Break = 1,

            Call = 2,

            Cond_Branch = 3,

            Meta = 4,

            Next = 5,

            Phi = 6,

            Return = 7,

            Throw = 8,
        }
    }
}