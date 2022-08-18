//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiSigs
    {
        [Op]
        public static ApiSig sig(MethodInfo src)
        {
            var @class = ApiClass.from(src);
            var @return = src.ReturnType;
            var @params = src.ParameterTypes();
            var count = @params.Length + 1;
            var components = sys.alloc<Type>(count);
            for(var i=0; i<count; i++)
            {
                if(i < count - 1)
                    components[i] = @params[i];
                else
                    components[i] = @return;
            }
            return sig(@class, components);
        }

        [MethodImpl(Inline), Op]
        public static ApiSig sig(Index<Type> args)
            => new ApiSig(args);

        [MethodImpl(Inline)]
        public static ApiSig sig(ApiClassKind @class, Type[] args)
            => new ApiSig(@class, args);
    }
}