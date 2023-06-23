//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    public interface IXedDisasmTarget
    {
        XedDisasmToken Starting(ProjectContext context, in FileRef src);

        void Finished(XedDisasmToken token);

        void Computing(uint seq, in Instruction src);

        void Computed(uint seq, in OpDetails src);

        void Computed(uint seq, in OperandState src);

        void Computed(uint seq, in AsmInfo src);

        void Computed(uint seq, in Fields src);

        void Computed(uint seq, ReadOnlySpan<FieldKind> src);

        void Computed(uint seq, in EncodingExtract src);

        void Computed(uint seq, in InstFieldValues src);

        void Computed(uint seq, in Instruction src);
    }
}