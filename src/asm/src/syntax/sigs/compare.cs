//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class AsmSigs
    {
        public static int compare(in AsmSig a, in AsmSig b)
        {
            var result = a.Mnemonic.CompareTo(b.Mnemonic);
            if(result == 0)
            {
                var count = min(a.OpCount, b.OpCount);
                for(var i=0; i<count; i++)
                {
                    var opA = a[i];
                    var opB = b[i];
                    var _result = opA.Format().CompareTo(opB.Format());
                    if(_result != 0)
                    {
                        result = _result;
                        break;
                    }
                }
            }
            return result;
        }
    }
}