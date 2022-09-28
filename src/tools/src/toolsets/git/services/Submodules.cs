//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tools
    {
        partial class Git
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
        }
    }
}