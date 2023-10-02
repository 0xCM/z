//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public class OpWidthSpecs
    {
        readonly Index<WidthCode,OpWidthSpec> Data;

        [MethodImpl(Inline)]
        public OpWidthSpecs(OpWidthSpec[] src)
        {
            Data = src;
        }

        public ref readonly OpWidthSpec this[WidthCode code]
        {
            [MethodImpl(Inline)]
            get => ref Data[code];
        }
    }
}
