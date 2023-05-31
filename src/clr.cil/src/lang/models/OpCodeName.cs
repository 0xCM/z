//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct CilModels
    {
        public readonly struct OpCodeName
        {
            readonly Cell128 Data = Cell128.Empty;

            [MethodImpl(Inline)]
            OpCodeName(ReadOnlySpan<char> src)
            {
                var count = src.Length;
                ref var dst = ref @as<Cell128,byte>(Data);
                for(var i=0; i<src.Length; i++)
                {
                    ref readonly var c = ref skip(src,i);
                    if(c != 0)
                        seek(dst,i) = (byte)skip(src,i);
                    else
                        break;
                }
            }

            [MethodImpl(Inline)]
            public OpCodeName(string src)
                : this(sys.span(src))
            {

            }

            [MethodImpl(Inline)]
            public static implicit operator OpCodeName(string src)
                => new OpCodeName(src);

            public string Format()
            {
                Span<char> dst = stackalloc char[16];
                var src = bytes(Data);
                var length = z8;
                for(var i=0; i<16; i++, length++)
                {
                    ref readonly var b = ref skip(src,i);
                    if(b != 0)
                        seek(dst,i);
                    else
                        break;
                }
                return sys.@string(slice(dst,0,length));
            }

            public override string ToString()
                => Format();
        }
    }
}