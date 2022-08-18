//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    // [Free]
    // public interface IWfStepId
    // {
    //     /// <summary>
    //     /// The fully-qualified host name
    //     /// </summary>
    //     string HostName {get;}

    //     /// <summary>
    //     /// The step token
    //     /// </summary>
    //     WfHostId Token {get;}
    // }

    // [Free]
    // public interface IWfStepId<H> : IWfStepId, IComparable<H>, IEquatable<H>
    //     where H : struct, IWfStepId<H>
    // {
    //     /// <summary>
    //     /// The step token
    //     /// </summary>
    //     WfHostId IWfStepId.Token
    //     {
    //         [MethodImpl(Inline)]
    //         get => new WfHostId((ulong)typeof(H).MetadataToken);
    //     }

    //     string IWfStepId.HostName
    //         => typeof(H).AssemblyQualifiedName;

    //     string Name
    //         => HostName;

    //     string ITextual.Format()
    //         => HostName;

    //     [MethodImpl(Inline)]
    //     bool IEquatable<H>.Equals(H src)
    //         => src.Token.Value == Token.Value;

    //     [MethodImpl(Inline)]
    //     int IComparable<H>.CompareTo(H src)
    //         => HostName.CompareTo(src.HostName);

    //     uint Hashed
    //     {
    //         [MethodImpl(Inline)]
    //         get => (uint)alg.hash.calc(typeof(H));
    //     }
    // }
}