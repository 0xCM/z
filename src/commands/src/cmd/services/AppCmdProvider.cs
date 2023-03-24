//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCmdProvider
    {
        readonly Type _ServiceType;

        public AppCmdProvider(Type svc)
        {
            _ServiceType = svc;
        }

        public Type ServiceType => _ServiceType;

        public IApiService Service(IWfRuntime wf)
        {
            var method = _ServiceType.Method("create");
            return (IApiService)method.Invoke(null, new object[]{wf});
        }
    }
}