//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        public static Type type(MemberInfo src)
        {
            var result = typeof(void);            
            if(src is Type t)
                result = t;
            if(src is PropertyInfo p)
                result = p.PropertyType;
            else if(src is FieldInfo f)
                result = f.FieldType;
            return result;
        }
    }
}