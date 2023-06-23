//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public interface IXedDisasmFlow
    {
        XedDisasmToken Run(in FileRef src, IXedDisasmTarget dst);
    }

    partial class XedDisasm
    {
        public delegate void DisasmReceiver<T>(uint seq, in T src);

        public delegate void OpStateReceiver(uint seq, in OperandState state, ReadOnlySpan<FieldKind> fields);

        public delegate void FieldReceiver(uint seq, in Fields src);

        public delegate void FileReceiver(ProjectContext context, in FileRef src);
    }
}