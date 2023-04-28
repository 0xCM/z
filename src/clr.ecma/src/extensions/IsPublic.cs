//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    
    partial class XTend
    {
        const TypeAttributes VisibilityMask = TypeAttributes.VisibilityMask;
         
        public static bool IsPublic(this TypeAttributes src)
        {
            var visibility = src & VisibilityMask;
            switch (visibility)
            {
                case TypeAttributes.Public:
                case TypeAttributes.NestedPublic:
                    return true;
                default:
                    return false;
            }
        }
    }
}