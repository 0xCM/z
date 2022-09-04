//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static BufferSeqId;
    using static CellDelegates;

    class ApiEvalExecutor : IApiEvalExecutor
    {
        readonly IWfRuntime Wf;

        readonly IBoundSource Source;

        readonly int RepCount;

        ApiEvalExecutorContext Context;

        [MethodImpl(Inline)]
        internal ApiEvalExecutor(IWfRuntime wf, IBoundSource source)
        {
            Wf = wf;
            RepCount = 128;
            Source = source;
            Context = new ApiEvalExecutorContext(source, 128, 0);
        }

        public TimedEval MatchBinaryOps(in NativeBuffers buffers, CpuCellWidth w, in ConstPair<MemberCodeBlock> paired)
        {
            var clock = Time.counter();
            try
            {
                switch(w)
                {
                    case CpuCellWidth.W8:
                        return MatchBinaryOps(buffers, n8, paired);

                    case CpuCellWidth.W16:
                        return MatchBinaryOps(buffers, n16, paired);

                    case CpuCellWidth.W32:
                        return MatchBinaryOps(buffers, n32, paired);

                    case CpuCellWidth.W64:
                        return MatchBinaryOps(buffers, n64, paired);

                    case CpuCellWidth.W128:
                        return MatchBinaryOps(buffers, n128, paired);

                    case CpuCellWidth.W256:
                        return MatchBinaryOps(buffers, n256, paired);

                    default:
                        return TimedEval.result(seq, (paired.Left.Uri, paired.Right.Uri), clock, AppMsg.error($"Handler not found"));
                }
            }
            catch(Exception error)
            {
                return TimedEval.result(seq, (paired.Left.Uri, paired.Right.Uri), clock, error);
            }
        }

        TimedEval MatchBinaryOps(in NativeBuffers buffers, N8 w, in ConstPair<MemberCodeBlock> pair)
        {
            var f = buffers[Left].EmitBinaryCellOp(w, pair.Left.Encoded);
            var g = buffers[Right].EmitBinaryCellOp(w, pair.Right.Encoded);
            return CheckMatch(f, pair.Left.Uri, g, pair.Right.Uri);
        }

        TimedEval MatchBinaryOps(in NativeBuffers buffers, N16 w, in ConstPair<MemberCodeBlock> pair)
        {
            var f = buffers[Left].EmitBinaryCellOp(w, pair.Left.Encoded);
            var g = buffers[Right].EmitBinaryCellOp(w, pair.Right.Encoded);
            return CheckMatch(f, pair.Left.Uri, g, pair.Right.Uri);
        }

        TimedEval MatchBinaryOps(in NativeBuffers buffers, N32 w, in ConstPair<MemberCodeBlock> pair)
        {
            var f = buffers[Left].EmitBinaryCellOp(w, pair.Left.Encoded);
            var g = buffers[Right].EmitBinaryCellOp(w, pair.Right.Encoded);
            return CheckMatch(f, pair.Left.Uri, g, pair.Right.Uri);
        }

        TimedEval MatchBinaryOps(in NativeBuffers buffers, N64 w, in ConstPair<MemberCodeBlock> pair)
        {
            var f = buffers[Left].EmitBinaryCellOp(w, pair.Left.Encoded);
            var g = buffers[Right].EmitBinaryCellOp(w, pair.Right.Encoded);
            return CheckMatch(f, pair.Left.Uri, g, pair.Right.Uri);
        }

        TimedEval MatchBinaryOps(in NativeBuffers buffers, N128 w, in ConstPair<MemberCodeBlock> pair)
        {
            var f = buffers[Left].EmitBinaryCellOp(w, pair.Left.Encoded);
            var g = buffers[Right].EmitBinaryCellOp(w, pair.Right.Encoded);
            return CheckMatch(f, pair.Left.Uri, g, pair.Right.Uri);
        }

        TimedEval MatchBinaryOps(in NativeBuffers buffers, N256 w, in ConstPair<MemberCodeBlock> pair)
        {
            var f = buffers[Left].EmitBinaryCellOp(w, pair.Left.Encoded);
            var g = buffers[Right].EmitBinaryCellOp(w, pair.Right.Encoded);
            return CheckMatch(f, pair.Left.Uri, g, pair.Right.Uri);
        }

        /// <summary>
        /// Verifies that two 32-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator, considered as a basline</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator, considered as the operation under test</param>
        /// <param name="gId">The identity of the second operator</param>
        public TimedEval CheckMatch(BinaryOp8 f, _OpUri fUri, BinaryOp8 g, _OpUri gUri)
            => ApiEvaluate.validate(Context, f, fUri, g, gUri);

        /// <summary>
        /// Verifies that two 32-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator, considered as a basline</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator, considered as the operation under test</param>
        /// <param name="gId">The identity of the second operator</param>
        public TimedEval CheckMatch(BinaryOp16 f, _OpUri fUri, BinaryOp16 g, _OpUri gUri)
        {
            var w = n16;
            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Source.Cell(w);
                    var y = Source.Cell(w);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ExecAction(check, fUri, gUri);
        }

        /// <summary>
        /// Verifies that two 32-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator, considered as a basline</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator, considered as the operation under test</param>
        /// <param name="gId">The identity of the second operator</param>
        public TimedEval CheckMatch(BinaryOp32 f, _OpUri fUri, BinaryOp32 g, _OpUri gUri)
        {
            var w = n32;
            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Source.Cell(w);
                    var y = Source.Cell(w);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ExecAction(check, fUri, gUri);
        }

        /// <summary>
        /// Verifies that two 32-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator, considered as a basline</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator, considered as the operation under test</param>
        /// <param name="gId">The identity of the second operator</param>
        public TimedEval CheckMatch(BinaryOp64 f, _OpUri fUri, BinaryOp64 g, _OpUri gUri)
        {
            var w = n64;
            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Source.Cell(w);
                    var y = Source.Cell(w);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ExecAction(check, fUri, gUri);
        }

        /// <summary>
        /// Verifies that two 32-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator, considered as a basline</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator, considered as the operation under test</param>
        /// <param name="gId">The identity of the second operator</param>
        public TimedEval CheckMatch(BinaryOp128 f, _OpUri fUri, BinaryOp128 g, _OpUri gUri)
        {
            var w = n128;
            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Source.Cell(w);
                    var y = Source.Cell(w);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ExecAction(check, fUri, gUri);
        }

        /// <summary>
        /// Verifies that two 32-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator, considered as a basline</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator, considered as the operation under test</param>
        /// <param name="gId">The identity of the second operator</param>
        public TimedEval CheckMatch(BinaryOp256 f, _OpUri fUri, BinaryOp256 g, _OpUri gUri)
        {
            var w = n256;

            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Source.Cell(w);
                    var y = Source.Cell(w);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ExecAction(check, fUri, gUri);
        }

        public TimedEval ExecAction(Action action, _OpUri f, _OpUri g)
        {

            var clock = Time.counter(true);
            try
            {
                action();
                return TimedEval.result(seq, (f,g), clock, true );
            }
            catch(Exception e)
            {
                return TimedEval.result(seq, (f,g), clock, e);
            }
        }

        static ICheckEquatable Claim => CheckEquatable.Checker;

        static int _checkseq;

        static int seq
        {
            [MethodImpl(Inline)]
            get => core.inc(ref _checkseq);
        }
    }
}