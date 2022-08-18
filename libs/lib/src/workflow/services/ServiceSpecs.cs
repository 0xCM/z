//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ServiceSpecs
    {
        public static ReadOnlySeq<ServiceSpec> discover(Assembly[] src)
        {
            var dst = list<ServiceSpec>();
            var types = src.Types().Tagged<ServiceCacheAttribute>().Concrete().ToSeq();
            for(var i=0; i<types.Count; i++)
            {
                ref readonly var type = ref types[i];
                var factories = type.PublicInstanceMethods().Concrete().Where(m => m.ReturnType.Reifies<IAppService>());
                if(factories.Length != 0)
                {
                    dst.Add(new AppServiceSpec(type,factories));
                }                
            }


            return dst.Array();
        }
    }
}