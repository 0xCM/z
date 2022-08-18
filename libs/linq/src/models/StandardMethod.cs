//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    public class StandardMethod
    {
        public StandardMethod()
        {

        }

        protected StandardMethod(string MethodName)
        {
            this.MethodName = MethodName;
        }

        public string MethodName { get; }
    }
}