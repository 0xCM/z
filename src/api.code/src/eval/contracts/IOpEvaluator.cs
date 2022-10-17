//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IOpEvaluator
    {
        Outcome<OpEvaluation> Evaluate(IOperation op);
    }

    [Free]
    public interface IOpEvaluator<S> : IOpEvaluator
    {
        S Body {get;}

        IOpSvc<S> OpSvc {get;}

        Outcome<OpEvaluation<S>> Evaluate(IOperation<S> op)
        {
            var success = OpSvc.Eval(Body, out var output);
            if(success)
                return new OpEvaluation<S>(op, Body, output);
            else
                return false;
        }

        Outcome<OpEvaluation> IOpEvaluator.Evaluate(IOperation op)
        {
            var outcome = Evaluate((IOperation<S>)op);
            return outcome ? new Outcome<OpEvaluation>(true,outcome.Data) : false;
        }
    }

    [Free]
    public interface IOpEvaluator<S,T> : IOpEvaluator<S>
    {
        new IOpSvc<S,T> OpSvc {get;}

        Outcome<OpEvaluation<S,T>> Evaluate(IOperation<S,T> op)
        {
            var success = OpSvc.Eval(Body, out var output);
            if(success)
                return new OpEvaluation<S,T>(op, Body, output);
            else
                return false;
        }

        Outcome<OpEvaluation<S>> IOpEvaluator<S>.Evaluate(IOperation<S> op)
        {
            var outcome = Evaluate((IOperation<S,T>)op);
            if(outcome)
            {
                var data = outcome.Data;
                return new Outcome<OpEvaluation<S>>(true,
                    new OpEvaluation<S>(data.Actor, data.Input, data.Output)
                    );
            }
            else
                return false;
        }
    }

    public interface IOpEvaluator<O,S,T> : IOpEvaluator<S,T>
        where O : IOperation<S,T>
    {
        Outcome<OpEvaluation<O,S,T>> Evaluate(O op)
        {
            var success = OpSvc.Eval(Body, out var output);
            if(success)
                return new OpEvaluation<O,S,T>(op, Body, output);
            else
                return false;
        }

        Outcome<OpEvaluation<S,T>> IOpEvaluator<S,T>.Evaluate(IOperation<S,T> e)
        {
            var outcome = Evaluate((O)e);
            if(outcome)
            {
                var data = outcome.Data;
                return new Outcome<OpEvaluation<S,T>>(true,
                    new OpEvaluation<S,T>(data.Actor, data.Input, data.Output)
                    );
            }
            else
                return false;
        }
    }
}