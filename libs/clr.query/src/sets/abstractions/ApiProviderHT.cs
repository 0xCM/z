//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiProvider<H,T>
        where H : ApiProvider<H,T>, new()
        where T : IApiSet<T>, new()
    {
        public Type Host
            => typeof(H);

        public Assembly Source  
            => Host.Assembly;
    }    
}