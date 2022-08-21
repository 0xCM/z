//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies a type that defines an interface-contracted api surface
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class FunctionalServiceAttribute : ApiHostAttribute
    {
        public FunctionalServiceAttribute()
        {

        }
    }
}