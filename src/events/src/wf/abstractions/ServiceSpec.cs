//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public abstract record class ServiceSpec
{
    protected readonly Assembly _Owner;

    protected readonly Type _Host;

    protected readonly ReadOnlySeq<MethodInfo> _Factories;

    protected ServiceSpec(Type host, MethodInfo[] factories)
    {
        _Owner = host.Assembly;
        _Host = host;
        _Factories = factories;
    }

    public ref readonly Assembly Owner 
        => ref _Owner;

    public ref readonly Type Host 
        => ref _Host;

    public ref readonly ReadOnlySeq<MethodInfo> Factories 
        => ref _Factories;

    public virtual string Format()
    {
        var dst = text.emitter();
        for(var i=0; i<_Factories.Count; i++)
        {
            ref readonly var factory = ref _Factories[i];
            var @return = factory.ReturnType.Unwrap();
            if(@return.IsNonEmpty())
                dst.AppendLine(@return.DisplayName());
        }

        return dst.Emit();
    }

    public sealed override string ToString()
        => Format();
}
