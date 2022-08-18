//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using FC = ImmFunctionKind;

    partial class XApi
    {
        /// <summary>
        /// Calculates a method's immediate class
        /// </summary>
        /// <param name="src">The method to classify</param>
        [Op]
        public static ImmFunctionKind ImmFunctionClass(this MethodInfo src, ImmRefinementKind refinement)
        {
            var found = src.ImmParameters(refinement);
            var count = found.Length;
            if(count == 0 || count > 2)
                return 0;

            var dst = FC.Imm8;
            var first = found.First();
            switch(count)
            {
                case 1:
                    dst |= FC.ImmCount1;
                    dst |= first.ImmSlot();
                break;

                case 2:
                    var second = found.Last();
                    dst |= FC.ImmCount2;
                    dst |= first.ImmSlot();
                    dst |= second.ImmSlot();
                break;
            }

            return dst;
        }
    }
}