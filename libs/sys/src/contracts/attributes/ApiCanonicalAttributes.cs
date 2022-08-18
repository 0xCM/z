//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiCanonicalClass;
    using A = OpKindAttribute;

    /// <summary>
    /// Identifies a target operation/type that transports A -> B
    /// </summary>
    public class FlowAttribute : A { public FlowAttribute() : base(K.Flow) {} }

    public class LoadAttribute : A { public LoadAttribute() : base(K.Load) {} }

    public class StoreAttribute : A { public StoreAttribute() : base(K.Store) {} }

    public sealed class IdentityFunctionAttribute : A { public IdentityFunctionAttribute() : base(K.Identity) {} }

    public sealed class IdentityValueAttribute : A { public IdentityValueAttribute() : base(K.Identity) {} }

    public sealed class ConcatAttribute : A { public ConcatAttribute() : base(K.Concat) {} }

    public sealed class ReverseAttribute : A { public ReverseAttribute() : base(K.Reverse) {} }

    public sealed class ParseAttribute : A { public ParseAttribute() : base(K.Parse) {} }

    public sealed class SliceAttribute : A { public SliceAttribute() : base(K.Slice) {} }

    public sealed class LoAttribute : A { public LoAttribute() : base(K.Lo) {} }

    public sealed class HiAttribute : A { public HiAttribute() : base(K.Hi) {} }

    public sealed class LeftAttribute : A { public LeftAttribute() : base(K.Left) {} }

    public sealed class RightAttribute : A { public RightAttribute() : base(K.Right) {} }

    public sealed class ReplicateAttribute : A { public ReplicateAttribute() : base(K.Replicate) {} }

    public sealed class SplitAttribute : A { public SplitAttribute() : base(K.Split) {} }

    public sealed class ToggleAttribute : A { public ToggleAttribute() : base(K.Toggle) {} }

    public sealed class ZeroAttribute : A { public ZeroAttribute() : base(K.Zero) {} }

    public sealed class OneAttribute : A { public OneAttribute() : base(K.One) {} }

    public sealed class TestAttribute : A { public TestAttribute() : base(K.Test) {} }

    public sealed class BroadcastAttribute : A { public BroadcastAttribute() : base(K.Broadcast) {} }

    public sealed class ZeroesAttribute : A { public ZeroesAttribute() : base(K.Zeroes) {} }

    public sealed class OnesAttribute : A { public OnesAttribute() : base(K.Ones) {} }

    public sealed class SwitchAttribute : A { public SwitchAttribute() : base(K.Switch) {} }

    public sealed class CopyAttribute : A { public CopyAttribute() : base(K.Copy) {} }

    public sealed class ZipAttribute : A { public ZipAttribute() : base(K.Zip) {} }

    public sealed class MapAttribute : A { public MapAttribute() : base(K.Map) {} }

    public sealed class VZipAttribute : A { public VZipAttribute() : base(K.VZip) {} }

    public sealed class VMapAttribute : A { public VMapAttribute() : base(K.VMap) {} }

    public sealed class BijectionAttribute : A { public BijectionAttribute() : base(K.Bijection) {} }

    public sealed class ConcretizerAttribute : A { public ConcretizerAttribute() : base(K.Concretizer){} }

    public sealed class ParseFunctionAttribute : A { public ParseFunctionAttribute() : base(K.ParseFunction){} }
}