//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        [MethodImpl(Inline), Op]
        public static IXedDisasmBuffer buffer(ProjectContext context, in FileRef src)
            => new ContextBuffer(src);

        [MethodImpl(Inline)]
        public static IXedDisasmFlow flow(ProjectContext context)
            => new XedDisasmFlow(context);

        static long DisasmTokens;

        [MethodImpl(Inline)]
        public static XedDisasmToken token()
            => (uint)sys.inc(ref DisasmTokens);

        public static XedDisasmDetail detail(ProjectContext context, in FileRef src)
            => detail(context, datafile(context, src));

        public static XedDisasmDetail detail(ProjectContext context, in XedDisasmFile src)
            => detail(summary(context,src));

        class ContextBuffer : IXedDisasmBuffer
        {
            readonly FileRef _Source;

            readonly Index<FieldKind> _FieldKinds;

            XedDisasmFile _DataFile;

            XedDisasmDetailBlock _Block;

            XedDisasmSummary _Summary;

            AsmInfo _AsmInfo;

            InstFieldValues _Props;

            public ref readonly FileRef Source
            {
                [MethodImpl(Inline)]
                get => ref _Source;
            }

            [MethodImpl(Inline)]
            public ref XedDisasmFile DataFile()
                => ref _DataFile;

            [MethodImpl(Inline)]
            public ref XedDisasmDetailBlock Block()
                => ref _Block;

            [MethodImpl(Inline)]
            public ref XedDisasmSummary Summary()
                => ref _Summary;

            [MethodImpl(Inline)]
            public ref AsmInfo AsmInfo()
                => ref _AsmInfo;

            [MethodImpl(Inline)]
            public ref InstFieldValues Props()
                => ref _Props;

            [MethodImpl(Inline)]
            public ref EncodingExtract Encoding()
                => ref _Encoding;

            public uint FieldCount;

            EncodingExtract _Encoding;

            object StateLock = new();

            uint IXedDisasmBuffer.FieldCount
                => FieldCount;

            public void State(uint seq, in OperandState state, OpStateReceiver receiver)
            {
                lock(StateLock)
                    receiver(seq, state, slice(_FieldKinds.View, 0, FieldCount));
            }

            public void Cache(ReadOnlySpan<FieldKind> src)
            {
                lock(StateLock)
                {
                    FieldCount = (uint)src.Length;
                    for(var i=0; i<src.Length; i++)
                        _FieldKinds[i] = skip(src,i);
                }
            }

            [MethodImpl(Inline)]
            public ContextBuffer(in FileRef src)
            {
                _Source = src;
                _FieldKinds = alloc<FieldKind>(Fields.MaxCount);
                _DataFile = XedDisasmFile.Empty;
                _Block = XedDisasmDetailBlock.Empty;
                _Summary = XedDisasmSummary.Empty;
                _AsmInfo = XedModels.AsmInfo.Empty;
                _Props = InstFieldValues.Empty;
                _Encoding = EncodingExtract.Empty;
            }
        }
    }
}