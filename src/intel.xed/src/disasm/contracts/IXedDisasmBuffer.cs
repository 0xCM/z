//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;
using static XedDisasm;

public interface IXedDisasmBuffer
{
    ref XedDisasmFile DataFile();

    ref XedDisasmDetailBlock Block();

    ref XedDisasmSummary Summary();

    ref AsmInfo AsmInfo();

    ref EncodingExtract Encoding();

    ref InstFieldValues Props();

    uint FieldCount {get;}

    ref readonly FilePath Source {get;}

    void Cache(ReadOnlySpan<FieldKind> src);

    void State(uint seq, in XedFieldState state, OpStateReceiver receiver);
}
