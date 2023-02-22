//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Asci
    {
        public static Outcome parse<S,N>(string src, N n, out S dst)
            where S : struct, IAsciSeq<S,N>
            where N : unmanaged, ITypeNat
        {
            var result = Outcome.Success;
            dst = new();
            var input = text.ifempty(src, EmptyString);
            if(input.Length > (int)n.NatValue)
                result = (false, AppMsg.CapacityExceeded(src,n).Format());
            else
                encode<S,N>(src, out dst);
            return result;
        }
    }
}