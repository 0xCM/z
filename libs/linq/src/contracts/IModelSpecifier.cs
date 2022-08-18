//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    public interface IModelSpecifier
    {
        object SpecifyModel();
    }

    public interface IModelSpecifier<out M> : IModelSpecifier
    {
        new M SpecifyModel();
    }
}