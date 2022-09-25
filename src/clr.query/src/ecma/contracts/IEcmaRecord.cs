//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaRecord
    {
        EcmaTableKind TableKind {get;}
    }

    public interface IEcmaRecord<T> : IEcmaRecord
        where T : unmanaged, IEcmaRecord<T>
    {
        EcmaTableKind IEcmaRecord.TableKind
            => typeof(T).Tag<EcmaRecordAttribute>().MapValueOrDefault(x => x.TableKind, EcmaTableKind.Invalid);
    }
}