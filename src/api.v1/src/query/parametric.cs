//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class ApiQuery
    {
        [Op]
        public static MethodInfo[] generic(Type host)
            => host.DeclaredMethods().OpenGeneric(1).Where(IsGeneric);

        [Op]
        public static MethodInfo[] nongeneric(Type host)
            => host.DeclaredMethods().NonGeneric().Where(IsNonGeneric);

        [Op]
        public static MethodInfo[] generic(IApiHost host)
            => generic(host.HostType);

        [Op]
        public static MethodInfo[] nongeneric(IApiHost host)
            => nongeneric(host.HostType);

        [Op]
        static bool IsGeneric(MethodInfo src)
            => src.Tagged<OpAttribute>() && src.Tagged<ClosuresAttribute>() && !src.AcceptsImmediate();

        [Op]
        static bool IsNonGeneric(MethodInfo src)
            => src.Tagged<OpAttribute>() && !src.AcceptsImmediate();

        [Op]
        static ApiGroupNG[] GroupNongeneric(IApiHost src)
            => (from d in DirectOpSpecs(src).GroupBy(op => op.Method.Name)
                select new ApiGroupNG(ApiIdentity.opid(d.Key), src, d)).Array();

        static IMultiDiviner Diviner
            => MultiDiviner.Service;

        [Op]
        static ApiMethodG[] GroupGeneric(IApiHost src)
             => from m in tagged(src).OpenGeneric()
                let closures = ApiIdentityKinds.NumericClosureKinds(m)
                where closures.Length != 0
                select new ApiMethodG(src, Diviner.GenericIdentity(m), GenericDefintion(m), closures);

        [MethodImpl(Inline), Op]
        static MethodInfo GenericDefintion(MethodInfo src)
            => src.IsGenericMethodDefinition ? src : src.GetGenericMethodDefinition();

        static IEnumerable<ApiMethodNG> DirectOpSpecs(IApiHost src)
            => from m in tagged(src).NonGeneric() select new ApiMethodNG(src, Diviner.Identify(m), m);

        static MethodInfo[] tagged(IApiHost src)
            => src.Methods.Storage.Tagged<OpAttribute>();
    }
}