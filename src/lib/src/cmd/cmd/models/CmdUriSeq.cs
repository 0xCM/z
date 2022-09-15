//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdUriSeq : Seq<CmdUriSeq,CmdUri>
    {
        public CmdUriSeq()
        {

        }

        public CmdUriSeq(CmdUri[] src)
            : base(src)
        {

        }

        public override string Delimiter => Eol;

        [MethodImpl(Inline)]
        public static implicit operator CmdUriSeq(CmdUri[] src)
            => new (src);
    }
}