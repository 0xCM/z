//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct SpecializedImmEvent : IWfEvent<SpecializedImmEvent>
    {
        public const string EventName = "SpecializedImm";

        public EventId EventId {get;}

        readonly ApiHostUri Host;

        readonly bool Generic;

        readonly ImmRefinementKind ImmSource;

        readonly Type Refinement;

        readonly FilePath TargetFile;

        public FlairKind Flair {get;}

        [MethodImpl(Inline)]
        public static SpecializedImmEvent refined(StepId step, ApiHostUri uri, bool generic, Type refinement, FilePath dst)
            => new SpecializedImmEvent(step, uri, generic, ImmRefinementKind.Refined, refinement, dst);

        [MethodImpl(Inline)]
        public static SpecializedImmEvent literal(StepId step, ApiHostUri uri, bool generic, FilePath dst)
            => new SpecializedImmEvent(step, uri, generic, ImmRefinementKind.Unrefined, typeof(void), dst);

        [MethodImpl(Inline)]
        public static SpecializedImmEvent define(StepId step, ApiHostUri uri, bool generic, FilePath dst, Type refinement)
            => new SpecializedImmEvent(step, uri, generic,
                refinement != null ? ImmRefinementKind.Refined : ImmRefinementKind.Unrefined,
                refinement,
                dst);

        [MethodImpl(Inline)]
        public SpecializedImmEvent(StepId step, ApiHostUri uri, bool generic, ImmRefinementKind source, Type refinement, FilePath dst)
        {
            EventId = EventId.define(EventName, step);
            Host = uri;
            Generic = generic;
            ImmSource = source;
            Refinement = refinement ?? typeof(void);
            TargetFile = FS.path(dst.Name);
            Flair = FlairKind.Ran;
        }

        public string Format()
            => Refinement.IsEmpty()
            ? RpOps.format(RpOps.PSx5, EventId, Host, Generic ? "generic" : "nongeneric", "unrefined", TargetFile.ToUri())
            : RpOps.format(RpOps.PSx5, EventId, Host, Generic ? "generic" : "nongeneric", Refinement.Name, TargetFile.ToUri());

        public SpecializedImmEvent Zero
            => default;

        public static SpecializedImmEvent Empty
            => default;
    }
}