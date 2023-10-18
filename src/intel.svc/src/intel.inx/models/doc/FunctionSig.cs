//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class IntrinsicsDoc
{
    public readonly record struct FunctionSig
    {
        public readonly Return Return;

        public readonly FunctionName Name;

        public readonly Parameters Params;

        [MethodImpl(Inline)]
        public FunctionSig(Return ret, string name, Parameters ops)
        {
            Return = ret;
            if(text.nonempty(name))            
                Require.equal(Chars.Underscore, name[0]);
            Name = FunctionName.parse(name);
            Params = ops ?? new();
        }

        public string Format()
            => string.Format("{0} {1}({2})", Return, Name, string.Join(", ", Params));

        public override string ToString()
            => Format();

        public static FunctionSig Empty => new (Return.Empty, EmptyString, new());
    }
}
