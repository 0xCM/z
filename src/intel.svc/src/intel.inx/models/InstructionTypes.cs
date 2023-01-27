//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntrinsicsDoc
    {
        public class InstructionTypes : List<InstructionType>
        {
            public string Format()
                => this.Delimit().Format();

            public override string ToString()
                => Format();

            public static InstructionTypes Empty => new();
        }
    }
}