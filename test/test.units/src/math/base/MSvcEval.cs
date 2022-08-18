//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class MSvcEval : AppService<MSvcEval>
    {
        IPolySource Source;

        uint Samples;

        protected override void OnInit()
        {
            Source = Rng.@default();
            Samples = Pow2.T14;
        }

        [Op]
        public Pairs<T> Run<F,G,T>(F f = default, G g = default)
            where T : unmanaged
            where F : unmanaged, IBinaryOp<T>
            where G : unmanaged, IBinaryOp<T>
        {
            var input = Source.Pairs<T>(Samples);
            var output = Tuples.pairs<T>(Samples);
            return Run(input, output, f, g );
        }

        [Op]
        public Pairs<T> Run<F,G,T>(Pairs<T> dst, F f = default, G g = default)
            where T : unmanaged
            where F : unmanaged, IBinaryOp<T>
            where G : unmanaged, IBinaryOp<T>
        {
            return Run(Source.Pairs<T>(dst.PointCount), dst, f, g);
        }

        [Op]
        public Pairs<T> Run<F,G,T>(Pairs<T> src, Pairs<T> dst, F f = default, G g = default)
            where T : unmanaged
            where F : unmanaged, IBinaryOp<T>
            where G : unmanaged, IBinaryOp<T>
        {
            var outcome =  Run((Pairings<T,T>)src, f, g, dst);
            return outcome;
        }

        [MethodImpl(Inline)]
        Pairs<R> Run<T0,T1,R,F,G>(in Pairings<T0,T1> src, F f, G g, Pairs<R> dst)
            where T0: unmanaged
            where T1: unmanaged
            where R : unmanaged
            where F : IFunc<T0,T1,R>
            where G : IFunc<T0,T1,R>
                => default(BinaryEvaluator<T0,T1,R>).Evaluate(src, f, g, dst);

        public readonly struct BinaryEvaluator<T0,T1,R>
            where T0: unmanaged
            where T1: unmanaged
            where R : unmanaged
        {
            [MethodImpl(Inline)]
            public Pairs<R> Evaluate<F,G>(Pairings<T0,T1> src, F f, G g, Pairs<R> dst)
                where F : IFunc<T0,T1,R>
                where G : IFunc<T0,T1,R>
            {
                var count = src.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var p = ref src[i];
                    var r1 = f.Invoke(p.Left, p.Right);
                    var r2 = g.Invoke(p.Left, p.Right);
                    dst[i] = (r1,r2);
                }
                return dst;
            }
        }
    }
}