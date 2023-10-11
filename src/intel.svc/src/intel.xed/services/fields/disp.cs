//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedFields
{
    [Op]
    public static Disp disp(in XedFieldState state, in AsmHexCode code)
    {
        var val = Disp.Zero;
        if(state.DISP_WIDTH != 0)
        {
            var width = state.DISP_WIDTH;
            var size = width/8;
            var offset = state.POS_DISP;
            switch(size)
            {
                case 1:
                    val = new Disp((sbyte)code[offset], NativeSizeCode.W8);
                break;
                case 2:
                    val = new Disp(slice(code.Bytes, offset, size).TakeInt16(), NativeSizeCode.W16);
                break;
                case 4:
                    val = new Disp(slice(code.Bytes, offset, size).TakeInt32(), NativeSizeCode.W32);
                break;
                case 8:
                    val = new Disp(slice(code.Bytes, offset, size).TakeInt64(), NativeSizeCode.W64);
                break;
            }
        }

        return val;
    }
}