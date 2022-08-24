//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Defines the literal '('
        /// </summary>
        [RenderLiteral(OpenTuple)]
        public const string OpenTuple = "(";

        /// <summary>
        /// Defines the literal ')'
        /// </summary>
        [RenderLiteral(CloseTuple)]
        public const string CloseTuple = ")";

        [RenderPattern(1, Tuple1)]
        public const string Tuple1 = OpenTuple + Slot0 + CloseTuple;

        [RenderPattern(2, Tuple2)]
        public const string Tuple2 = "({0}, {1})";

        [RenderPattern(3, Tuple3)]
        public const string Tuple3 = "({0}, {1}, {2})";

        [RenderPattern(4, Tuple4)]
        public const string Tuple4 = "({0}, {1}, {2}, {3})";

        [RenderPattern(5, Tuple5)]
        public const string Tuple5 = "({0}, {1}, {2}, {3}, {4})";

        [RenderPattern(6, Tuple6)]
        public const string Tuple6 = "({0}, {1}, {2}, {3}, {4}, {5})";

        [RenderPattern(7, "({0}, {1}, {2}, {3}, {4}, {5}, {6})")]
        public const string Tuple7 = "({0}, {1}, {2}, {3}, {4}, {5}, {6})";
    }
}