import { CmdKind, CmdName, CmdSpec } from "./tool.actions"

export {}

export type CabalCmd = 
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


export type CabalCmdClass = 
    | "global"  
    | "package"
    | "projects"


export interface CabalCmdName extends CmdName<CabalCmd> { }

export interface CabalCmdKind extends CmdKind<CabalCmdClass> {}

export interface CabalCmdSpec extends CabalCmdName, CabalCmdKind, CmdSpec<CabalCmd,CabalCmdClass> {}

export type CabalCmdSpecs = Array<CabalCmdSpec>

let specs:CabalCmdSpecs = [
    {
        Name:"v2-build",
        Kind:"package",
        Intent:"Compile targets within the project",
    }
    ,
    {
        Name:"v2-bench",
        Kind:"package",
        Intent:"",    
    }
    ,
    {
        Name:"v2-clean",
        Kind:"package",
        Intent:"",   
    }
    ,
    {
        Name:"v2-configure",
        Intent:"",
        Kind:"package"
    }
    ,
    {
        Name:"v2-exec",
        Intent:"",    
        Kind:"package"    
    }
    ,
    {
        Name:"v2-freeze",
        Intent:"",    
        Kind:"package"    
    }
    ,
    {
        Name:"v2-haddock",
        Intent:"",    
        Kind:"package"    
    }
    ,
    {
        Name:"v2-install",
        Intent:"",    
        Kind:"package"    
    }
    ,
    {
        Name:"v2-repl",
        Intent:"",    
        Kind:"package"    
    }
    ,
    {
        Name:"v2-run",
        Intent:"",    
        Kind:"package"    
    }
    ,
    {
        Name:"v2-sdist",
        Intent:"",    
        Kind:"package"    
    }
    ,
    {
        Name:"v2-install",
        Intent:"",    
        Kind:"package"    
    }

]