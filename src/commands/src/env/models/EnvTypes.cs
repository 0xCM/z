//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static TypeSystems;

    [TypeSystem(SystemName)]
    public class EnvTypes : TypeSystem<EnvTypes>
    {
        public const string SystemName = "env";

        public abstract class TypeDef<R,T,A> : TypeDef<R,EnvTypes,T,A>
            where R : TypeDef<R,T,A>, new()
        {

        }

        [TypeDef(SystemName,TypeName)]
        public sealed class File : TypeDef<File,FilePath,@string>
        {
            public const string TypeName = "file";

            public override FilePath Value(@string args)
                => new (args);
        }

        [TypeDef(SystemName,TypeName)]
        public sealed class Folder : TypeDef<Folder,FolderPath,@string>
        {
            public const string TypeName = "folder";

            public override FolderPath Value(@string args)
                => new (args);
        }

        [TypeDef(SystemName,TypeName)]
        public sealed class Variable : TypeDef<Variable,EnvVar,Pair<@string>>
        {
            public const string TypeName = "var";

            public override EnvVar Value(Pair<@string> src)
                => new (src.Left,src.Right);
        }
    }
}