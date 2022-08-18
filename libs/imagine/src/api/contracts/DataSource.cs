//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiDataSource<H> : IApiDataSource
        where H : ApiDataSource<H>
    {
        readonly ApiUri _Name;

        public ref readonly ApiUri Name 
            => ref _Name;

        protected ApiDataSource(ApiUri name)
        {
            _Name = name;
        }
    }
}