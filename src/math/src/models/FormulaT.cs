//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class Formulas
    {
        public class Context
        {

        }

        public abstract class Expr
        {
            public readonly ReadOnlySeq<Expr> Nodes;

            protected Expr(params Expr[] src) 
            {
                Nodes = src;
            }
        }

        public abstract class Expr<T> : Expr
        {
            public abstract T Evaluate(Context context);
        }


        public class Formua<T> : Expr<T>
        {
            public override T Evaluate(Context context)
            {
                throw new NotImplementedException();
            }
        }

        public abstract class Operator : Expr
        {

        }

        public class Group : Expr
        {
            public Group(params Expr[] src)
                : base(src)
            {

            }
        }

        public class Var<T> : Expr<T>
        {

            public override T Evaluate(Context context)
            {
                throw new NotImplementedException();
            }
        }


        public class Literal<T> : Expr<T>
        {
            readonly T Value;

            public Literal(T value)
            {
                Value = value;
            }

            public override T Evaluate(Context context)
                => Value;
        }

        public class BooleanVar : Var<bool>
        {

        }

        public abstract class BooleanExpr : Expr<bool>
        {
            
        }

    }
}