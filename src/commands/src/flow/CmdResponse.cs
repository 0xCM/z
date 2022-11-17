//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdResponse
    {
        public string Key {get;}

        public string Val {get;}

        [MethodImpl(Inline)]
        public CmdResponse(string key, string val)
        {
            Key = key;
            Val = val;
        }

        public void Deconstruct(out string key, out string val)
        {
            key = Key;
            val = Val;
        }

        public string Format()
            => string.Format("{0}:{1}", Key, Val);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdResponse((string key, string val) src)
            => new CmdResponse(src.key, src.val);

        public static CmdResponse Empty => new CmdResponse(EmptyString, EmptyString);
    }
}