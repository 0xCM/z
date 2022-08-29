//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IIdentityDiviner
    {

    }

    /// <summary>
    /// Characterizes a service that attempts to assign a non-cryptic identity to a
    /// subject that is both useful and unique within the intended scope
    /// </summary>
    /// <typeparam name="S">The type of the thing to identify</typeparam>
    /// <typeparam name="T">The target identity type</typeparam>
    [Free]
    public interface IIdentityDiviner<S,T> : IIdentityDiviner
        where T : IIdentified
    {
        /// <summary>
        /// Reifies an identity divination algorithm
        /// </summary>
        /// <param name="src">The divinity source</param>
        T DivineIdentity(S src);
    }

    /// <summary>
    /// Characterizes a services that attempts to assign a reasonable identity to a type
    /// </summary>
    [Free]
    public interface ITypeIdentityDiviner : IIdentityDiviner<Type,TypeIdentity>
    {

    }

    /// <summary>
    /// Characterizes a service that attempts to assign a reasonable identity to a method
    /// </summary>
    [Free]
    public interface IMethodIdentityDiviner : IIdentityDiviner<MethodInfo,OpIdentity>
    {

    }

    [Free]
    public interface IDelegateIdentityDiviner : IIdentityDiviner<Delegate,OpIdentity>
    {

    }

    [Free]
    public interface IMultiDiviner : ITypeIdentityDiviner, IMethodIdentityDiviner, IDelegateIdentityDiviner
    {
        OpIdentity Identify(MethodInfo src)
            => DivineIdentity(src);

        TypeIdentity Identify(Type src)
            => DivineIdentity(src);

        OpIdentityG GenericIdentity(MethodInfo src);
    }
}