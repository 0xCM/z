//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdArgs : Seq<CmdArgs,CmdArg>
    {
        public CmdArgs()
        {

        }

        [MethodImpl(Inline)]
        public CmdArgs(CmdArg[] src)
            : base(src)
        {
            Data = src;
        }

        public override string Format()
        {
            if(Count > 0)
            {
                var dst = text.emitter();
                for(var i=0; i<Count; i++)
                {
                    dst.Append(this[i].Value);
                    if(i != Count - 1)
                        dst.Append(Chars.Space);
                }
                return dst.Emit();
            }
            else
            {
                return EmptyString;
            }
        }

        // [MethodImpl(Inline)]
        // public static implicit operator CmdArgs(CmdArg[] src)
        //     => new CmdArgs(src);
    }
}