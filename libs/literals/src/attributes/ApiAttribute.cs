//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiAttribute : OpAttribute
    {
        public readonly string Spec;

        public ApiAttribute()
        {
            Spec = EmptyString;
        }

        public ApiAttribute(string spec)
        {
            Spec = spec;
        }
    }
}