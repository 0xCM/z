//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdScript
    {
        public readonly @string Name;

        public readonly @string Body;
        
        [MethodImpl(Inline)]
        public CmdScript(string name, string body)
        {
            Name = name;
            Body = body;
        }

        public string Format()
            => Body.Format();

        public override string ToString()
            => Format();

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Body.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Body.IsNonEmpty;
        }

        public static CmdScript Empty
        {
            [MethodImpl(Inline)]
            get => new CmdScript(EmptyString, EmptyString);
        }
    }
}