//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IBinaryModule : IExpr
{
    FilePath Path {get;}

    string IExpr.Format()
        => $"{Path}";

    bool INullity.IsEmpty
        => Path.IsEmpty;

    bool INullity.IsNonEmpty
        => Path.IsNonEmpty;

    FileModuleKind ModuleKind {get;}
}

[Free]
public interface IBinaryModule<T> : IBinaryModule
    where T : IBinaryModule<T>, new()
{

}
