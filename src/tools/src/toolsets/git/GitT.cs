//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class Git
    {
        [ApiHost("git.submodules")]
        public class Submodules
        {
            [Op]
            public static Submodule define(FileUri local, HttpsUri remote)
                => new Submodule(local,remote);

            [Op]
            public static AddSubmodule add(Submodule src)
                => new (src);                
        }

        [Cmd(CmdId)]
        public struct ArchiveRepo : IFlowCmd<FolderPath,FilePath>
        {
            const string CmdId = "repo/archive";

            public Actor Actor;

            public FolderPath Source;

            public FilePath Target;

            FolderPath IFlowCmd<FolderPath, FilePath>.Source
                => Source;

            FilePath IFlowCmd<FolderPath, FilePath>.Target
                => Target;

            IActor IFlowCmd.Actor
                => Actor;
        }

        public struct Submodule
        {
            public FileUri Local;

            public HttpsUri Remote;

            public Submodule(FileUri local, HttpsUri remote)
            {
                Remote = remote;
                Local = local;
            }                
        }

        public struct AddSubmodule : IApiCmd<AddSubmodule>
        {
            public Submodule Submodule;

            public AddSubmodule(Submodule src)            
            {
                Submodule = src;
            }
        }       
    }
}