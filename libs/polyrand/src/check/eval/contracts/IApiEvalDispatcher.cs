//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiEvalDispatcher
    {
        bit EvalCellOperators(BufferTokens buffers, MemberCodeBlock[] api);

        void Dispatch(BufferTokens buffers, in MemberCodeBlock api, BinaryOperatorClass k);

        void Dispatch(BufferTokens buffers, in MemberCodeBlock api, UnaryOperatorClass k);

        bit EvalCellOperator(BufferTokens buffers, in MemberCodeBlock api);
    }
}