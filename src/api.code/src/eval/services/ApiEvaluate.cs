//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static BufferSeqId;
using static CellDelegates;

[ApiHost]
public readonly partial struct ApiEvaluate
{
    public static ApiEvalResult<ApiEvalExecutorContext> validate(ApiEvalExecutorContext context, in NativeBuffers buffers, BinaryOperatorClass k, N8 w, in ConstPair<MemberCodeBlock> pair)
    {
        var f = buffers[Left].EmitBinaryCellOp(w, pair.Left.Encoded);
        var g = buffers[Right].EmitBinaryCellOp(w, pair.Right.Encoded);
        return validate(context, f, pair.Left.Uri, g, pair.Right.Uri);
    }

    static void check(ApiEvalExecutorContext context, BinaryOp8 f, BinaryOp8 g)
    {
        var w = n8;
        for(var i=0; i <context.PointCount; i++)
        {
            var x = context.DataSource.Cell(w);
            var y = context.DataSource.Cell(w);
            Require.invariant(f(x,y) == g(x,y), () => $"{x} != {y}");
        }
    }

    /// <summary>
    /// Verifies that two 32-bit binary operators agree over a random set of points
    /// </summary>
    /// <param name="f">The first operator, considered as a basline</param>
    /// <param name="fId">The identity of the first operator</param>
    /// <param name="g">The second operator, considered as the operation under test</param>
    /// <param name="gId">The identity of the second operator</param>
    public static ApiEvalResult<ApiEvalExecutorContext> validate(ApiEvalExecutorContext context, BinaryOp8 f, OpUri fUri, BinaryOp8 g, OpUri gUri)
    {
        return exec(context, () => check(context, f, g), fUri, gUri);
    }

    public static ApiEvalResult<ApiEvalExecutorContext> exec(ApiEvalExecutorContext context, Action action, OpUri f, OpUri g)
    {
        var clock = Time.counter(true);
        try
        {
            action();
            var outcome =  TimedEval.result(context.Sequence, (f,g), clock, true );
            return (outcome, context);
        }
        catch(Exception e)
        {
            var outcome = TimedEval.result(context.Sequence, (f,g), clock, e);
            return (outcome, context);
        }
    }

    [MethodImpl(Inline), Op]
    public static IApiEvalDispatcher dispatcher(IWfRuntime wf, IBoundSource source, uint bufferSize)
        => new ApiEvalDispatcher(wf, source, bufferSize);

    [MethodImpl(Inline), Op]
    public static IApiEvalExecutor executor(IWfRuntime wf, IBoundSource source)
        => new ApiEvalExecutor(wf, source);

    public static ref readonly UnaryEvaluations<T> compute<T>(in UnaryApiEvalContext<T> exchange, Action<Exception> error)
        where T : unmanaged
    {
        @try(exchange, error);
        return ref exchange.Target;
    }

    public static ref readonly BinaryEvaluations<T> compute<T>(in BinaryApiEvalContext<T> exchange, Action<Exception> error)
        where T : unmanaged
    {
        @try(exchange, error);
        return ref exchange.Target;
    }

    static void @try<T>(in UnaryApiEvalContext<T> exchange, Action<Exception> handler)
        where T : unmanaged
    {
        try
        {
            var buffer = exchange.Buffers[Left];
            var code = exchange.ApiCode;

            if(!CheckBufferSize(code, buffer, out var msg))
                term.print(msg);

            var f = exchange.Member.Method.CreateDelegate<UnaryOp<T>>();
            var g = DFx.unaryop<T>(buffer, code.Encoded);
            var reps = exchange.PointCount;
            for(var i=0; i<reps; i++)
            {
                ref readonly var x = ref exchange.Input[i];
                exchange.Outcomes[i] = (f(x), g(x));
            }

        }
        catch(Exception e)
        {
            handler(e);
        }
    }

    static void @try<T>(in BinaryApiEvalContext<T> exchange, Action<Exception> handler)
        where T : unmanaged
    {
        try
        {
            var buffer = exchange.Buffers[Left];
            var code = exchange.ApiCode;

            if(!CheckBufferSize(code, buffer, out var msg))
                term.print(msg);

            var f = exchange.Member.Method.CreateDelegate<BinaryOp<T>>();
            var g = DFx.binaryop<T>(buffer, code.Encoded);
            var reps = exchange.PointCount;
            for(var i=0; i<reps; i++)
            {
                ref readonly var pair = ref exchange.Input[i];
                ref readonly var x = ref pair.Left;
                ref readonly var y = ref pair.Right;
                exchange.Outcomes[i] = (f(x,y), g(x, y));
            }

        }
        catch(Exception e)
        {
            handler(e);
        }
    }

    static bool CheckBufferSize(MemberCodeBlock code, BufferToken buffer, out AppMsg msg)
    {
        if(buffer.BufferSize < code.Encoded.Length)
        {
            msg = Msg.BufferSizeError(code,buffer);
            return false;
        }
        else
        {
            msg = AppMsg.colorize("Nothing there", FlairKind.Disposed);
            return true;
        }
    }
}

partial struct Msg
{
    public static AppMsg BufferSizeError(MemberCodeBlock code, BufferToken buffer)
        => AppMsg.info($"There are {buffer.BufferSize} available buffer bytes but at least {code.Length} is required by {code.Member.Id}");
}

public static partial class XTend
{
    public static IApiEvalDispatcher EvalDispatcher(this IWfRuntime wf, IBoundSource source = null, uint? buffersize = null)
        => ApiEvaluate.dispatcher(wf, source ?? Rng.@default(), buffersize ?? Pow2.T14);
}
