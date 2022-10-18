//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tools
    {
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
    }    
}