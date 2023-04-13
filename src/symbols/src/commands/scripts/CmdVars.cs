//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdVars : Seq<CmdVars, CmdVar>
    {
        public CmdVars()
        {

        }

        [MethodImpl(Inline)]
        public CmdVars(CmdVar[] src)
        {
            Data = src;
        }

        public override string Format()
            => CmdScripts.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVars(CmdVar[] src)
            => new CmdVars(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar[](CmdVars src)
            => src.Data;
    }
}