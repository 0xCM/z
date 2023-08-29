//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;

    public interface ITestCaseIdentity : IClaimValidator
    {
        /// <summary>
        /// Produces a test case name predicated on an operation identity
        /// </summary>
        /// <param name="id">Identifies the operation under test</param>
        string name(OpIdentity id)
            => TestCaseIdentity.from(HostType, id);

        /// <summary>
        /// Produces a test case name predicated on a parametrically-specialized label
        /// </summary>
        /// <param name="label">The case label</param>
        /// <typeparam name="T">The label specialization type</typeparam>
        string name<T>([CallerName] string label = null)
            where T : unmanaged
                => TestCaseIdentity.name<T>(HostType, label);

        string name<W,T>([CallerName] string label = null, bool generic = true)
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => ApiIdentityBuilder.name<W,T>(HostType, label, generic);

        string name<W,C>(Type host, string label, bool generic)
            where W : unmanaged, ITypeWidth
            where C : unmanaged
                => ApiIdentityBuilder.name<W,C>(host, label, generic);

        /// <summary>
        /// Produces a case name for an identified operation match test
        /// </summary>
        /// <param name="f">The left operation</param>
        /// <param name="g">The right operation</param>
        string match(OpIdentity f, OpIdentity g)
            => TestCaseIdentity.match(HostType, f, g);
    }
}