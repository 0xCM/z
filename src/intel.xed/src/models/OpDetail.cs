//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct OpDetail
    {
        public OpSpec Spec;

        public OpWidthDetail OpWidth;

        public OpName OpName;

        public OpData Def;

        public @string RuleDescription;

        public TextBlock DefDescription;

        public string Format()
            => DefDescription;

        public override string ToString()
            => Format();
    }
}