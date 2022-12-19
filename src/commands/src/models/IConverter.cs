//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    using System.Linq;

    public interface IModelConverter
    {
        IEnumerable<IModel> Convert(IEnumerable<IModel> src);
    }

    public interface IModelConverter<S,T> : IModelConverter
        where S : IModel<S>, new()
        where T : IModel<T>, new()
    {
        IEnumerable<T> Convert(IEnumerable<T> src);

        IEnumerable<IModel> IModelConverter.Convert(IEnumerable<IModel> src)
            => Convert(from m in src select m);
    }
}