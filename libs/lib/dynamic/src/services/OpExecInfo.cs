//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class OpExecInfo
    {
        public Identifier FunctionName;

        public Index<object> Input;

        public object Output;

        public @string Description;

        public OpExecInfo(Identifier name, object[] input, object output, @string description)
        {
            FunctionName = name;
            Input = input;
            Output = output;
            Description = description;
        }

        public string Format()
            => Description;

        public override string ToString()
            => Format();
    }
}