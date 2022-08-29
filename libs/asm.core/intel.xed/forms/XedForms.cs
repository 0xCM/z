//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class XedForms : WfSvc<XedForms>
    {
        XedPaths XedPaths => Wf.XedPaths();

        public static ref readonly Index<FormToken> tokens()
            => ref TokenData.TokenIndex;

        [MethodImpl(Inline)]
        public static ReadOnlySpan<FormToken> tokens(FormTokenKind kind)
            => TokenData.Tokens(kind);

        [MethodImpl(Inline)]
        public ref readonly Index<FormTokenKind> tokenkinds()
            => ref TokenData.Kinds;

        public void EmitTokens()
        {
            var src = tokens();
            var dst = alloc<FormTokenInfo>(src.Count);
            for(var i=0u; i<src.Count; i++)
            {
                ref readonly var token = ref src[i];
                ref var record = ref seek(dst,i);
                record.Seq = i;
                record.TokenKind = token.Kind;
                record.TokenValue = token;
            }

            TableEmit(@readonly(dst), XedPaths.Table<FormTokenInfo>());
        }

        static XedFormTokens _Tokens;

        public static ref readonly XedFormTokens TokenData
        {
            [MethodImpl(Inline)]
            get => ref _Tokens;
        }

        static XedForms()
        {
            _Tokens = TokenLoader.load();
        }
    }
}