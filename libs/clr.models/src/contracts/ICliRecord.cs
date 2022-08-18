//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICliRecord
    {
        CliTableKind TableKind {get;}
    }

    public interface ICliRecord<T> : ICliRecord
        where T : unmanaged, ICliRecord<T>
    {
        CliTableKind ICliRecord.TableKind
            => typeof(T).Tag<CliRecordAttribute>().MapValueOrDefault(x => x.TableKind, CliTableKind.Invalid);
    }
}