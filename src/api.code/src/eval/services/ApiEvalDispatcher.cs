//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    using K = OperatorClasses;

    class ApiEvalDispatcher : IApiEvalDispatcher
    {
        readonly IWfRuntime Wf;

        readonly IBoundSource DataSource;

        readonly uint BufferSize;

        [MethodImpl(Inline)]
        public ApiEvalDispatcher(IWfRuntime wf, IBoundSource source, uint bufferSize)
        {
            Wf = wf;
            DataSource = source;
            BufferSize = bufferSize;
        }


        uint PointCount<T>()
            => size<T>()/BufferSize;

        ApiMemberEvaluator Evaluator(BufferTokens buffers)
            => new ApiMemberEvaluator(buffers);

        Pair<string> Labels => ("method", "asm");

        PairEvalResults<T> init<T>()
            where T : unmanaged
        {
            var count = PointCount<T>();
            var dst = Tuples.index(sys.alloc<Pair<T>>(count));
            return ApiEval.pairs(Labels, dst);
        }

        void error(Exception e)
        {
            Wf.Error(e);
        }

        UnaryEvaluations<T> eval<T>(BufferTokens buffers, in MemberCodeBlock code, UnaryOperatorClass<T> k)
            where T : unmanaged
        {
            var target = init<T>();
            var src = DataSource.Array<T>(target.PointCount);
            var context = ApiEval.context(buffers, code, ApiEval.unary(src, target));
            return ApiEvaluate.compute(context, error);
        }

        BinaryEvaluations<T> eval<T>(BufferTokens buffers, in MemberCodeBlock code, BinaryOperatorClass<T> k)
            where T : unmanaged
        {
            var target = init<T>();
            var src = DataSource.Pairs<T>(target.PointCount);
            var context = ApiEval.context(buffers, code, ApiEval.binary(src, target));
            return ApiEvaluate.compute(context, error);
        }

        ApiMemberEvaluator Evaluator<E,T>(BufferTokens buffers, IOperationClass<E,T> k)
            where T : unmanaged
            where E : unmanaged, Enum
                => Evaluator(buffers);

        public bit EvalCellOperators(BufferTokens buffers, MemberCodeBlock[] api)
        {
            for(var i=0; i<api.Length; i++)
                EvalCellOperator(buffers, api[i]);
            return 0;
        }

        /// <summary>
        /// Produces an homogenous point index of dimension 2
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="count">The number of points to load into the index</param>
        /// <typeparam name="T">The coordinate domain</typeparam>
        public Pairs<F> FixedPairs<F>(int count, F t = default)
            where F : unmanaged, IDataCell
        {
            var s1 = DataSource.Cells<F>().Take(count);
            var s2 = DataSource.Cells<F>().Take(count);
            return s1.Zip(s2).Select(a =>  Tuples.pair(a.First, a.Second)).ToArray();
        }

        public bit EvalCellOperator(BufferTokens buffers, in MemberCodeBlock api)
        {
            var nk = api.Method.ReturnType.NumericKind();
            var kid = api.Member.ApiClass;
            var count = 128;
            var n = n2;

            if(kid == ApiClassKind.Div || kid == ApiClassKind.Mod)
                return 0;

            var apiclass = api.Method.ClassifyOperator();
            switch(apiclass)
            {
                case ApiOperatorKind.BinaryOp:
                switch(nk)
                {
                    case NumericKind.U8:
                    case NumericKind.I8:
                        return Dispatch(buffers, FixedPairs<Cell8>(count), api);
                    case NumericKind.I16:
                    case NumericKind.U16:
                        return Dispatch(buffers, FixedPairs<Cell16>(count), api);
                    case NumericKind.I32:
                    case NumericKind.U32:
                        return 0;
                    case NumericKind.I64:
                    case NumericKind.U64:
                        return 0;
                    default:
                        return 0;
                }

                default:
                    return 0;
            }
        }

        HashSet<ApiClassKind> EvalSkip {get;}
            = new HashSet<ApiClassKind>(array(ApiClassKind.Inc));

        void Analyze<T>(in MemberCodeBlock api, in UnaryEvaluations<T> eval)
            where T : unmanaged
        {
            if(EvalSkip.Contains(api.KindId))
                return;

            var name = api.Member.Id.Name;
            var sample = 0;
            var sampleMax = 10;
            var fp = typeof(T).IsFloatingPoint();

            var xLabel = eval.LeftLabel;
            var yLabel = eval.RightLabel;

            for(var i=0; i<eval.Count; i++, sample++)
            {
                ref readonly var input = ref eval.Source[i];
                ref readonly var result = ref eval.Target;

                var x = result[i].Left;
                var y = result[i].Right;

                if(!fp)
                    Require.invariant(gmath.eq(x,y), () => $"{x} != {y}");
            }
        }

       void Analyze<T>(in MemberCodeBlock api, in BinaryEvaluations<T> eval)
            where T : unmanaged
        {
            if(EvalSkip.Contains(api.KindId))
                return;

            var name = api.Member.Id.Name;
            var sample = 0;
            var sampleMax = 10;
            var fp = typeof(T).IsFloatingPoint();

            var xLabel = eval.LeftLabel;
            var yLabel = eval.RightLabel;

            for(var i=0; i<eval.PointCount; i++, sample++)
            {
                ref readonly var input = ref eval.Source[i];
                ref readonly var result = ref eval.Target;
                var x = result[i].Left;
                var y = result[i].Right;
                if(!fp)
                    Require.invariant(gmath.eq(x,y), () => $"{x} != {y}");
            }
        }

        public void Dispatch(BufferTokens buffers, in MemberCodeBlock api, UnaryOperatorClass k)
        {
            var kid = api.Member.ApiClass;
            int count = 128;
            if(kid == 0 || kid == ApiClassKind.Div || kid == ApiClassKind.Mod)
                return;

            var nk = api.Method.ReturnType.NumericKind();
            try
            {
                switch(nk)
                {
                    case NumericKind.U8:
                        Analyze(api, eval(buffers, api, k.As<byte>()));
                        break;
                    case NumericKind.I8:
                        Analyze(api, eval(buffers, api, k.As<sbyte>()));
                        break;
                    case NumericKind.I16:
                        Analyze(api, eval(buffers, api, k.As<short>()));
                        break;
                    case NumericKind.U16:
                        Analyze(api, eval(buffers, api, k.As<ushort>()));
                        break;
                    case NumericKind.I32:
                        Analyze(api, eval(buffers, api, k.As<int>()));
                        break;
                    case NumericKind.U32:
                        Analyze(api, eval(buffers, api, k.As<uint>()));
                        break;
                    case NumericKind.I64:
                        Analyze(api, eval(buffers, api, k.As<long>()));
                        break;
                    case NumericKind.U64:
                        Analyze(api, eval(buffers, api, k.As<ulong>()));
                        break;
                    case NumericKind.F32:
                        Analyze(api, eval(buffers, api, k.As<float>()));
                        break;
                    case NumericKind.F64:
                        Analyze(api, eval(buffers, api, k.As<double>()));
                        break;
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
        }

        public void Dispatch(BufferTokens buffers, in MemberCodeBlock api, BinaryOperatorClass k)
        {
            var kid = api.Member.ApiClass;
            int count = 128;
            if(kid == 0 || kid == ApiClassKind.Div || kid == ApiClassKind.Mod)
                return;

            var nk = api.Method.ReturnType.NumericKind();
            try
            {
                switch(nk)
                {
                    case NumericKind.U8:
                        Analyze(api, eval(buffers, api, k.As<byte>()));
                        break;
                    case NumericKind.I8:
                        Analyze(api, eval(buffers, api, k.As<sbyte>()));
                        break;
                    case NumericKind.I16:
                        Analyze(api, eval(buffers, api, k.As<short>()));
                        break;
                    case NumericKind.U16:
                        Analyze(api, eval(buffers, api, k.As<ushort>()));
                        break;
                    case NumericKind.I32:
                        Analyze(api, eval(buffers, api, k.As<int>()));
                        break;
                    case NumericKind.U32:
                        Analyze(api, eval(buffers, api, k.As<uint>()));
                        break;
                    case NumericKind.I64:
                        Analyze(api, eval(buffers, api, k.As<long>()));
                        break;
                    case NumericKind.U64:
                        Analyze(api, eval(buffers, api, k.As<ulong>()));
                        break;
                    case NumericKind.F32:
                        Analyze(api, eval(buffers, api, k.As<float>()));
                        break;
                    case NumericKind.F64:
                        Analyze(api, eval(buffers, api, k.As<double>()));
                        break;
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
        }

        /// <summary>
        /// Loads executable code into an index-identifed target buffer and manufactures a fixed binary operator
        /// that executes the code in the buffer upon invocation
        /// </summary>
        /// <param name="buffers">The target buffer sequence</param>
        /// <param name="index">The index of the target buffer</param>
        /// <param name="src">The executable source that conforms to a fixed binary operator</param>
        /// <typeparam name="F">The operand type</typeparam>
        BinaryOp<F> LoadFixedinaryOp<F>(BufferTokens buffers, BufferSeqId index, MemberCodeBlock src)
            where F : unmanaged, IDataCell
                => buffers[index].EmitBinaryCellOp<F>(src.Encoded);

        /// <summary>
        /// Loads and invokes a fixed binary operator
        /// </summary>
        /// <param name="buffers">The target buffer sequence</param>
        /// <param name="index">The index of the target buffer</param>
        /// <param name="src">The executable source that conforms to a fixed binary operator</param>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <typeparam name="F">The operand type</typeparam>
        F ExecBinaryOp<F>(BufferTokens buffers, BufferSeqId index, MemberCodeBlock src, F x, F y)
            where F : unmanaged, IDataCell
                => LoadFixedinaryOp<F>(buffers, index, src)(x,y);

        void Analyze(in Pairs<byte> src, in Triples<byte> dst, in MemberCodeBlock api)
        {
            for(var i=0; i< 10; i++)
            {
                ref readonly var eval = ref dst[i];
                var x0 = eval[n0];
                var x1 = eval[n1];
                var x2 = eval[n2];
            }
        }

        bit Dispatch(BufferTokens buffers, in Pairs<byte> src, in MemberCodeBlock api)
        {

            var dst = Evaluator(buffers).Eval(api, K.binary(), src);
            Analyze(src, dst, api);
            return 1;
        }

        void Analyze(in Pairs<Cell8> src, in Triples<Cell8> dst, in MemberCodeBlock api)
        {
            for(var i=0; i< 10; i++)
            {
                ref readonly var eval = ref dst[i];
                var x0 = eval[n0];
                var x1 = eval[n1];
                var x2 = eval[n2];
            }
        }

        Bit32 Dispatch(BufferTokens buffers, in Pairs<Cell8> src, in MemberCodeBlock api)
        {

            var dst = Evaluator(buffers).EvalCellular(api, K.binary(), src);
            Analyze(src, dst, api);
            return 1;
        }

        Bit32 Dispatch(BufferTokens buffers, in Pairs<Cell16> src, in MemberCodeBlock api)
        {

            var dst = Evaluator(buffers).EvalCellular(api, K.binary(), src);
            Analyze(src, dst, api);
            return 1;
        }

        void Analyze<T>(in Pairs<T> src, in Triples<T> dst, in MemberCodeBlock api)
            where T : unmanaged
        {

        }

        Triples<T> Dispatch<E,T>(BufferTokens buffers, in MemberCodeBlock api, IOperationClass<E,T> k, in Pairs<T> src)
            where E : unmanaged, Enum
            where T : unmanaged
        {

            var evaluator = Evaluator(buffers, k);
            var dst = evaluator.Eval(api, K.binary(), src);
            Analyze(src, dst, api);
            return dst;
        }
    }
}