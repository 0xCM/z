//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CmdArgParser 
    {
        struct State
        {
            public ReadOnlySeq<string> Src;

            public uint SrcPos;

            public CmdArgs Dst;

            public uint DstPos;

            public Token LastToken;

            public Error Error;
        }

        enum Error : byte
        {
            None,

            Bad
        }

        enum Token : byte
        {
            Char,

            Space,

            Dash,

            Dashes,
        }

        static void name(ReadOnlySpan<char> src, out string dst)
        {
            dst = EmptyString;
            Span<char> buffer = stackalloc char[src.Length];
            var j=0;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(SQ.whitespace(c))
                    break;
                seek(buffer,j++) = c;
            }
            dst = sys.@string(slice(buffer,0, j));
        }

        static void step(ref State state) 
        {
            ref readonly string input = ref state.Src[state.SrcPos];
            ref var output = ref state.Dst[state.DstPos];
            var chars = span(input);
            for(var i=0; i<chars.Length; i++)
            {
                if(state.Error != 0)
                    break;

                ref readonly var c = ref skip(chars,i);                
                switch(c)
                {
                    case Chars.Dash:
                        switch(state.LastToken)
                        {
                            case Token.Char:

                            break;
                            case Token.Dash:
                                state.LastToken = Token.Dashes;                                
                            break;
                            case Token.Dashes:
                                state.Error = Error.Bad;
                            break;
                            case Token.Space:
                                state.LastToken = Token.Space;
                            break;
                        }
                    break;
                    case Chars.Space:
                        switch(state.LastToken)
                        {
                            case Token.Char:
                            break;
                            case Token.Dash:
                            break;
                            case Token.Dashes:
                            break;
                            case Token.Space:
                            break;
                        }
                    break;
                    default:
                    break;
                
                }
            }
        }

        static void parse(ref State state)
        {
            for(var i=0; i< state.Src.Count; state.SrcPos++)
                step(ref state);

        }

        public CmdArgs Parse(string[] src)
        {
            var dst = CmdArgs.Empty;
            var state = new State {
                Src = src,
                SrcPos = 0,
                Dst = sys.alloc<CmdArg>(src.Length),
                DstPos = 0,
                Error = 0,
            };
            parse(ref state);

            return state.Dst;
        }
    }
}