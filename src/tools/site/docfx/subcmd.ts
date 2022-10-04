
export type SubCmdName = 
| 'build' 
| 'dependency' 
| 'download' 
| 'help' 
| 'init' 
| 'merge' 
| 'metadata' 
| 'pdf' 
| 'serve' 
| 'template'

export type SubCmdNames = Array<SubCmdName>

const subcmdnames : SubCmdNames = ['build','dependency','download','help','init','merge','metadata','pdf', 'serve','template']

export type SubCmd<C extends SubCmdName> = {
cmd:C,
info:string
}

function subcommand<C extends SubCmdName>(cmd:C, info:string) : SubCmd<C> {
return {
    cmd,
    info
}
}

export const SubCommands = {
names: subcmdnames,
build: subcommand('build','Generate client-only website combining API in YAML files and conceptual files'),
dependency:subcommand('dependency','Export dependency file'),
download:subcommand('download','Download remote xref map file and create an xref archive in local.'),
help:subcommand('help','Get an overall guide for the command and sub-commands'),
merge:subcommand('merge','Merge .net base API in YAML files and toc files.'),
metadata:subcommand('metadata','Generate YAML files from source code'),
pdf:subcommand('pdf','Generate pdf file'),
serve:subcommand('serve','Host a local static website'),
template:subcommand('template','List or export existing template'),

}

export function subcommands() {
return SubCommands
}
/*
build           : Generate client-only website combining API in YAML files and conceptual files
dependency      : Export dependency file
download        : Download remote xref map file and create an xref archive in local.
help            : Get an overall guide for the command and sub-commands
init            : Generate an initial docfx.json following the instructions
merge           : Merge .net base API in YAML files and toc files.
metadata        : Generate YAML files from source code
pdf             : Generate pdf file
serve           : Host a local static website
template        : List or export existing template

*/
/*
Usage1: docfx metadata [<docfx.json file path>]


Usage2: docfx metadata <code project1> [<code project2>] ... [<code projectN>]

-f, --force               Force re-generate all the metadata
--shouldSkipMarkup        Skip to markup the triple slash comments
-o, --output              Specify the output base directory
--raw                     Preserve the existing xml comment tags inside 
                        'summary' triple slash comments
-h, --help                Print help message for this sub-command
--filter                  Specify the filter config file
--globalNamespaceId       Specify the name to use for the global namespace
--property                --property <n1>=<v1>;<n2>=<v2> An optional set of 
                        MSBuild properties used when interpreting project 
                        files. These are the same properties that are 
                        passed to msbuild via the 
                        /property:<n1>=<v1>;<n2>=<v2> command line argument
--disableGitFeatures      Disable fetching Git related information for 
                        articles. By default it is enabled and may have 
                        side effect on performance when the repo is large.
--disableDefaultFilter    Disable the default API filter (default filter only
                        generate public or protected APIs).
-l, --log                 Specify the file name to save processing log
--logLevel                Specify to which log level will be logged. By 
                        default log level >= Info will be logged. The 
                        acceptable value could be Verbose, Info, Warning, 
                        Error.
--repositoryRoot          Specify the GIT repository root folder.
--correlationId           Specify the correlation id used for logging.
--warningsAsErrors        Specify if warnings should be treated as errors.

*/