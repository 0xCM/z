//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        [Op]
        public static ImmRefinementKind ClassifyImmRefinement(this ParameterInfo src)
        {
            if(!src.Tagged<ImmAttribute>())
                return ImmRefinementKind.None;
            else
                return src.ParameterType.IsEnum ? ImmRefinementKind.Refined : ImmRefinementKind.Unrefined;
        }
    }
}