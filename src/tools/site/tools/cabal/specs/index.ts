type CmdName<N> = N

type CmdKind<K> = K
    
type CmdSpec<N,K> ={
    name:N
    kind:K
    desc?:string
}

export type SubCmd = 
    | "update"            // Updates list of known packages.
    | "install"           // Install packages.
    | "help"              // Help about commands.
    | "info"              // Display detailed information about a particular package.
    | "list"              // List packages matching a search string.
    | "fetch"             // Downloads packages for later installation.
    | "user-config"       // Display and update the user's global cabal configuration.
    | "get"               // Download/Extract a package's source code (repository).
    | "init"              // Create a new .cabal package file.
    | "configure"         // Add extra project configuration
    | "build"             // Compile targets within the project.
    | "clean"             // Clean the package store and remove temporary files.
    | "run"               // Run an executable.
    | "repl"              // Open an interactive session for the given component.
    | "test"              // Run test-suites
    | "bench"             // Run benchmarks
    | "check"             // Check the package for common mistakes.
    | "sdist"             // Generate a source distribution file (.tar.gz).
    | "upload"            // Uploads source packages or documentation to Hackage.
    | "report"            // Upload build reports to a remote server.
    | "freeze"            // Freeze dependencies.
    | "gen-bounds"        // Generate dependency bounds.
    | "outdated"          // Check for outdated dependencies
    | "haddock"           // Build Haddock documentation
    | "hscolour"          // Generate HsColour colourised code, in HTML format.
    | "exec"              // Give a command access to the store.
    | "list-bin"          // list path to a single executable.
    | "v2-build"          // Compile targets within the project.
    | "v2-configure"      // Add extra project configuration
    | "v2-repl"           // Open an interactive session for the given component.
    | "v2-run"            // Run an executable.
    | "v2-test"           // Run test-suites
    | "v2-bench"          // Run benchmarks
    | "v2-freeze"         // Freeze dependencies.
    | "v2-haddock"        // Build Haddock documentation
    | "v2-exec"           // Give a command access to the store.
    | "v2-update"         // Updates list of known packages.
    | "v2-install"        // Install packages.
    | "v2-clean"          // Clean the package store and remove temporary files.
    | "v2-sdist"          // Generate a source distribution file (.tar.gz).


export type CmdClass = 
    | "global"  
    | "package"
    | "projects"


type CabalCmdName = CmdName<SubCmd>

type CabalCmdKind = CmdKind<CmdClass>

export type CabalCmdSpec = CmdSpec<CabalCmdName,CabalCmdKind>

export type CabalCmdSpecs = Array<CabalCmdSpec>

export const specs:CabalCmdSpecs = [
    {
        name:"v2-build",
        kind:"package",
        desc:"Compile targets within the project",
    }
    ,
    {
        name:"v2-bench",
        kind:"package",
        desc:"",    
    }
    ,
    {
        name:"v2-clean",
        kind:"package",
        desc:"",   
    }
    ,
    {
        name:"v2-configure",
        kind:"package",
        desc:"",
    }
    ,
    {
        name:"v2-exec",
        kind:"package",   
        desc:"",    
    }
    ,
    {
        name:"v2-freeze",
        kind:"package",
        desc:"",    
    }
    ,
    {
        name:"v2-haddock",
        desc:"",    
        kind:"package"    
    }
    ,
    {
        name:"v2-install",
        kind:"package",    
        desc:"",    
    }
    ,
    {
        name:"v2-repl",
        kind:"package",   
        desc:"",    
    }
    ,
    {
        name:"v2-run",
        kind:"package",   
        desc:"",    
    }
    ,
    {
        name:"v2-sdist",
        kind:"package",    
        desc:"",    
    }
    ,
    {
        name:"v2-install",
        kind:"package",
        desc:"",    
    }
]