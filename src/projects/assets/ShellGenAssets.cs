//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    sealed class ShellGenAssets : Assets<ShellGenAssets>
    {
        public Asset AppMain() 
            => Asset("shellgen/app.cs.template");

        public Asset Part() 
            => Asset("shellgen/part.cs.template");

        public Asset OmnisharpSettings() 
            => Asset("shellgen/omnisharp.json.template");

        public Asset DirectoryBuildProps() 
            => Asset("shellgen/directory.build.props.template");
        
        public Asset ShellProject()
            => Asset("shellgen/app.csproj.template");
    }
}