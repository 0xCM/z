//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AppEventSource : IWfHost
    {
        public readonly Type Type {get;}

        [MethodImpl(Inline)]
        public AppEventSource(Type type)
        {
            Type = type;
        }

        [MethodImpl(Inline)]
        public static implicit operator StepId(AppEventSource src)
            => new StepId(src.Type.Name);

        [MethodImpl(Inline)]
        public static implicit operator AppEventSource(Type src)
            => new AppEventSource(src);                

        [MethodImpl(Inline)]
        public static implicit operator Type(AppEventSource src)
            => src.Type;
    }
}