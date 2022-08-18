//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public delegate void DisasmReceiver<T>(uint seq, in T src);

        public delegate void OpStateReceiver(uint seq, in OperandState state, ReadOnlySpan<FieldKind> fields);

        public delegate void FieldReceiver(uint seq, in Fields src);

        public delegate void FileReceiver(FileFlowContext context, in FileRef src);

        public interface IFlow
        {
            DisasmToken Run(in FileRef src, ITarget dst);
        }

        public interface ITarget
        {
            DisasmToken Starting(FileFlowContext context, in FileRef src);

            void Finished(DisasmToken token);

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

        public interface IContextBuffer
        {
            ref DataFile DataFile();

            ref DetailBlock Block();

            ref XedDisasmSummary Summary();

            ref AsmInfo AsmInfo();

            ref EncodingExtract Encoding();

            ref InstFieldValues Props();

            uint FieldCount {get;}

            ref readonly FileRef Source {get;}

            void Cache(ReadOnlySpan<FieldKind> src);

            void State(uint seq, in OperandState state, OpStateReceiver receiver);
        }
    }
}