//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    using System.Linq;

    using static TypedLogicSpec;

    public class t_variables : t_logix<t_variables>
    {
        public void check_compositions()
        {
            var ops = NumericLogixHost.BinaryLogicKinds.ToArray();
            var pairs = from op1 in ops
                        from op2 in ops
                        select (op1, op2);
            pairs.Iter(o => check_4x2(o.op1,o.op2));

        }

        public void check_binop_vars()
        {
            NumericLogixHost.BinaryLogicKinds.ToArray().Iter(check_binop_vars);
        }

        public void check_solution()
        {
            var x = variable<uint>(0u);
            var y = literal(27u);
            var expr1 = varied(n1, and(x,y),x);
            var expr2 = y;
            var result = solve(expr1, expr2,(1,0xA0));
            Notify($"Expression is satisfied by {result.Count} values");
            Claim.nea(result.IsEmpty());
        }

        public void minimize()
        {
            var v1 = variable<uint>(0u);
            var v2 = variable<uint>(1u);
            var expr1 = varied(n2, or(v2, xor(v1, and(v1, nand(v2, not(v1))))),v1,v2);
            var expr2 = literal(32u);
            var result = solve(expr1, expr2, (1,0xA0));
            Notify($"Expression is satisfied by {result.Count} values");
        }

        IReadOnlyList<T> solve<T>(VariedExpr<N1,T> expr, LogixLiteral<T> match, Interval<T> domain)
            where T : unmanaged, IEquatable<T>
        {
            var dst = new List<T>();
            var level = domain.Increments<T>();
            var count = level.Length;
            for(var i=0; i<count; i++)
            {
                expr.Var0(level[i]);
                var result = LogixEngine.eval(expr.BaseExpr);
                if(gmath.eq(result.Value, match.Value))
                    dst.Add(result);
            }
            return dst;
        }

        IReadOnlyList<T> solve<T>(VariedExpr<N2,T> expr, LogixLiteral<T> match, Interval<T> domain)
            where T : unmanaged, IEquatable<T>
        {
            var sln = new List<T>();
            var level0 = domain.Increments<T>();
            var level1 = domain.Increments<T>();
            for(var i=0; i<level0.Length; i++)
            {
                expr.Var0(level0[i]);
                for(var j=0; j<level1.Length; j++)
                {
                    expr.Var1(level1[j]);

                    var result = LogixEngine.eval(expr.BaseExpr);
                    if(gmath.eq(result.Value, match.Value))
                        sln.Add(result);
                }
            }
            return sln;
        }

        void check_4x2(BinaryBitLogicKind k0, BinaryBitLogicKind k1)
        {
            check_4x2<byte>(k0,k1);
            check_4x2<ushort>(k0,k1);
            check_4x2<uint>(k0,k1);
            check_4x2<ulong>(k0,k1);
        }

        void check_4x2<T>(BinaryBitLogicKind k0, BinaryBitLogicKind k1)
            where T : unmanaged
        {
            var v0 = variable<T>(0u);
            var v1 = variable<T>(1u);
            var v2 = variable<T>(2u);
            var v3 = variable<T>(3u);

            var op0_name = k0.Format();
            var op1_name = k1.Format();
            var v0_name = v0.Format(false);
            var v1_name = v1.Format(false);
            var v2_name = v2.Format(false);
            var v3_name = v3.Format(false);
            var method = MethodInfo.GetCurrentMethod().DisplayName<T>();

            var expr = binary(k1, binary(k0, v0,v1), binary(k0, v2,v3));
            var op0 = NumericLogixHost.lookup<T>(k0);
            var op1 = NumericLogixHost.lookup<T>(k1);

            for(var i=0; i<RepCount; i++)
            {
                var a = Random.SetNext(v0);
                var b = Random.SetNext(v1);
                var c = Random.SetNext(v2);
                var d = Random.SetNext(v3);

                var expect = op1(op0(a,b), op0(c,d));
                var actual = LogixEngine.eval(expr).Value;
                Claim.eq(expect,actual);
            }
        }

        void check_binop_vars(BinaryBitLogicKind kind)
        {
            check_binop_vars<byte>(kind);
            check_binop_vars<ushort>(kind);
            check_binop_vars<uint>(kind);
            check_binop_vars<ulong>(kind);
        }

        void check_binop_vars<T>(BinaryBitLogicKind kind)
            where T : unmanaged
        {
            var v0 = variable<T>(0u);
            var v1 = variable<T>(1u);

            var op = NumericLogixHost.lookup<T>(kind);
            var expr = binary(kind,v0,v1);
            for(var i=0; i< RepCount; i++)
            {
                var a = Random.SetNext(v0);
                var b = Random.SetNext(v1);
                var expect = op(a, b);
                var actual = LogixEngine.eval(expr).Value;
                Claim.eq(expect,actual);
            }
        }
    }
}