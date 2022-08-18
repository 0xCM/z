//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WfHost : IWfHost<WfHost>
    {
        public Type Type {get;}

        [MethodImpl(Inline)]
        public WfHost(Type type)
        {
            Type = type;
        }

        [MethodImpl(Inline)]
        public static implicit operator WfStepId(WfHost src)
            => new WfStepId(src.Type.Name);

        [MethodImpl(Inline)]
        public static implicit operator WfHost(Type src)
            => new WfHost(src);
    }
}