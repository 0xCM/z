//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiValidator<V> : AppService<V>
        where V : ApiValidator<V>,new()
    {
        protected IPolySource Source {get; private set;}

        public static V create(IWfRuntime wf, IPolySource src)
        {
            var service = create(wf);
            service.Source = src;
            return service;
        }

        protected ApiValidator()
        {
            SampleCount = Pow2.T12;
        }

        protected uint SampleCount {get;}

        public abstract void Validate();
    }

    public abstract class ApiValidator<V,C> : AppService<V>
        where V : ApiValidator<V,C>,new()
    {
        protected IPolySource Source {get; private set;}

        public static V create(IWfRuntime wf, IPolySource src)
        {
            var service = create(wf);
            service.Source = src;
            return service;
        }

        protected ApiValidator()
        {
            SampleCount = Pow2.T12;
        }

        protected uint SampleCount {get;}

        public abstract void Validate(C context);
    }
}