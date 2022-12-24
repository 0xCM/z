//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiQuery
    {
        [Op]
        public static Index<IApiClass> kinds()
        {
            var types = @readonly(typeof(ApiClasses).GetNestedTypes().NonGeneric().Realize<IApiClass>());
            var count = types.Length;
            var classes = alloc<IApiClass>(count);
            ref var dst = ref first(classes);
            for(var i=0; i<count; i++)
                seek(dst,i) = (IApiClass)Activator.CreateInstance(skip(types,i));
            return classes;
        }
    }
}