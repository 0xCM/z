//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MsgPattern
    {
        public string PatternText {get;}

        [MethodImpl(Inline)]
        public MsgPattern(string src)
        {
            PatternText = src;
        }

        public string Format(params object[] src)
        {
            var count = src?.Length ?? 0;

            if(count == 0)
                return PatternText;

            var items = new string[count];
            for(var i=0; i<count; i++)
                items[i] = string.Format("<{0}>", src[i]);
            return string.Format(PatternText, items);
        }

        [MethodImpl(Inline)]
        public static implicit operator MsgPattern(string src)
            => new MsgPattern(src);
    }
}