//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Binary
    {
        public interface IExpr : Z0.IExpr
        {
            dynamic Evaluate();
        }

        public interface IExpr<T> : IExpr
        {
            new T Evaluate();

            dynamic IExpr.Evaluate() 
                => Evaluate();
        }

        public static Align align(BitWidth width, BitWidth segment)
            => new(width,segment);

        public readonly struct Align : IExpr<BitWidth>
        {
            public readonly BitWidth Width;

            public readonly BitWidth Segment;

            public Align(BitWidth width, BitWidth segment)
            {
                Width = width;
                Segment = segment;
            }

            public bool IsEmpty
            {
                get => Width == 0 || Segment == 0;
            }

            public bool IsNonEmpty
            {
                get => Width != 0 && Segment !=0;
            }

            public BitWidth Evaluate()
                => BinaryCalcs.align(Width, Segment);
            public string Format()
                => $"align({Width}, {Segment})";

            public override string ToString()
                => Format();
        }
    }
}