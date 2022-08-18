//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct CmdResponse
    {
        public static ReadOnlySpan<CmdResponse> parse(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var parsed = list<CmdResponse>();
            for(var i=0; i<count; i++)
            {
                if(CmdResponse.parse(skip(src,i).Content, out var response))
                    parsed.Add(response);
            }
            return parsed.ViewDeposited();
        }

        public static bool parse(string src, out CmdResponse dst)
        {
            dst = CmdResponse.Empty;
            var i = text.index(src, Chars.Colon);
            if(i > 0)
            {
                var left = text.left(src, i);
                var right = text.right(src,i);
                dst = (left,right);
                return true;
            }
            else
                return false;
        }

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