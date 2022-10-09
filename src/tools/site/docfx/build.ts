import {Folder,File, Literal} from "../core"

import * as IO from "./io"

export type LogLevel = | 'Verbose' | 'Info' | 'Warning' | 'Error'

export type BuildOptions = {
    project:File<string>,
    cleanupCacheHistory?:boolean,
    output?:string,
    debug?:boolean,
    debugOutput?:string,
    loglevel?:LogLevel,
    log?:string,
    rawModelOutputFolder?:string,
    viewModelOutputFolder?:string,
    intermediateFolder?:string
}

function format(options:BuildOptions) : string {
    var command = `docfx ${options.project}`
    if(options.cleanupCacheHistory)
        command += ' --cleanupCacheHistory'
    if(options.output != null)
        command += ` --output ${options.output}`
    if(options.debugOutput != null)
        command += ` --debug --debugOutput ${options.debugOutput}`
    if(options.loglevel != null)
        command += ` --loglevel ${options.loglevel}`
    if(options.rawModelOutputFolder != null)
        command += ` --exportRawModel --rawModelOutputFolder ${options.rawModelOutputFolder}`
    if(options.viewModelOutputFolder != null)
        command += ` --exportViewModel --viewModelOutputFolder ${options.viewModelOutputFolder}`
    if(options.intermediateFolder != null)
        command += ` --intermediateFolder ${options.intermediateFolder}`
    return command;
}

export function build<P,S,T>(project: P, src:S, dst:T) {
    const raw = `--exportRawModel --rawModelOutputFolder ${dst}/docs/docs/raw`
    const view = `--exportViewModel --viewModelOutputFolder ${dst}/docs/docs/view`
    const dbg = `--debug --debugOutput ${dst}/docs/docs/debug`
    const site = `--output ${dst}/docs/docs/site`
    const obj = `--intermediateFolder ${dst}/docs/docs/obj`
    return `docfx build ${src}/${project}.json --cleanupCacheHistory --loglevel Verbose ${site} ${dbg} ${raw} ${view} ${obj}`
}

/*
docfx build 
    d:/dev/projects/docs/sources/dotnet/docs/docfx.json 
    --cleanupCacheHistory 
    --output d:/dev/projects/docs/targets/docs/docs/site 
    --debug 
    --debugOutput d:/dev/projects/docs/targets/docs/docs/debug 
    --loglevel Verbose 
    --exportRawModel 
    --rawModelOutputFolder d:/dev/projects/docs/targets/docs/docs/raw 
    --exportViewModel 
    --viewModelOutputFolder d:/dev/projects/docs/targets/docs/docs/view 
    --intermediateFolder d:/dev/projects/docs/targets/docs/docs/obj

*/

export function options<R extends Literal,P>(project:P, def:File<string>, build:Folder<R>) : BuildOptions  {
    return {
    project:def,
    cleanupCacheHistory:true,
    output:`${IO.outdir(IO.output(build,project,'site'))}`,
    debugOutput:`${IO.outdir(IO.output(build,project,'debug'))}`,
    loglevel:'Verbose',
    log:`${IO.outfile(IO.output(build,project,'log'))}`,
    rawModelOutputFolder:`${IO.outdir(IO.output(build,project,'raw'))}}`,
    viewModelOutputFolder:`${IO.outdir(IO.output(build,project,'view'))}`,
    intermediateFolder:`${IO.outdir(IO.output(build,project,'obj'))}`,
    }
}

export function help() {
    return BuildCmdHelp
}

const BuildCmdHelp = `
Usage: docfx build [<config file path>]

  -o, --output                  Specify the output base directory
  -h, --help                    Print help message for this sub-command
  --content                     Specify content files for generating 
                                documentation.
  --resource                    Specify resources used by content files.
  --overwrite                   Specify overwrite files used by content files.
  -x, --xref                    Specify the urls of xrefmap used by content 
                                files.
  --xrefService                 Specify the urls of xrefService for resolving 
                                xref used by content files.
  -t, --template                Specify the template name to apply to. If not 
                                specified, output YAML file will not be 
                                transformed.
  --theme                       Specify which theme to use. By default 
                                'default' theme is offered.
  -s, --serve                   Host the generated documentation to a website
  -n, --hostname                Specify the hostname of the hosted website 
                                (e.g., 'localhost' or '*')
  -p, --port                    Specify the port of the hosted website
  -f, --force                   Force re-build all the documentation
  --debug                       Run in debug mode. With debug mode, raw model 
                                and view model will be exported automatically 
                                when it encounters error when applying 
                                templates. If not specified, it is false.
  --debugOutput                 The output folder for files generated for 
                                debugging purpose when in debug mode. If not 
                                specified, it is {TempPath}/docfx
  --forcePostProcess            Force to re-process the documentation in post 
                                processors. It will be cascaded from force 
                                option.
  --globalMetadata              Specify global metadata key-value pair in json 
                                format. It overrides the globalMetadata 
                                settings from the config file.
  --globalMetadataFile          Specify a JSON file path containing 
                                globalMetadata settings, as similar to 
                                {"globalMetadata":{"key":"value"}}. It 
                                overrides the globalMetadata settings from the 
                                config file.
  --globalMetadataFiles         Specify a list of JSON file path containing 
                                globalMetadata settings, as similar to 
                                {"key":"value"}. It overrides the 
                                globalMetadata settings from the config file.
  --fileMetadataFile            Specify a JSON file path containing 
                                fileMetadata settings, as similar to 
                                {"fileMetadata":{"key":"value"}}. It overrides 
                                the fileMetadata settings from the config file.
  --fileMetadataFiles           Specify a list of JSON file path containing 
                                fileMetadata settings, as similar to 
                                {"key":"value"}. It overrides the fileMetadata 
                                settings from the config file.
  --exportRawModel              If set to true, data model to run template 
                                script will be extracted in .raw.model.json 
                                extension
  --rawModelOutputFolder        Specify the output folder for the raw model. If
                                not set, the raw model will be generated to the
                                same folder as the output documentation
  --viewModelOutputFolder       Specify the output folder for the view model. 
                                If not set, the view model will be generated to
                                the same folder as the output documentation
  --exportViewModel             If set to true, data model to apply template 
                                will be extracted in .view.model.json extension
  --dryRun                      If set to true, template will not be actually 
                                applied to the documents. This option is always
                                used with --exportRawModel or --exportViewModel
                                is set so that only raw model files or view 
                                model files are generated.
  --maxParallelism              Set the max parallelism, 0 is auto.
  --markdownEngineName          Set the name of markdown engine, default is 
                                'dfm'.
  --markdownEngineProperties    Set the parameters for markdown engine, value 
                                should be a JSON string.
  --noLangKeyword               Disable default lang keyword.
  --intermediateFolder          Set folder for intermediate build results.
  --changesFile                 Set changes file.
  --postProcessors              Set the order of post processors in plugins
  --lruSize                     Set the LRU cached model count (approximately 
                                the same as the count of input files). By 
                                default, it is 8192 for 64bit and 3072 for 
                                32bit process. With LRU cache enabled, memory 
                                usage decreases and time consumed increases. If
                                set to 0, Lru cache is disabled.
  --keepFileLink                If set to true, docfx does not dereference 
                                (aka. copy) file to the output folder, instead,
                                it saves a link_to_path property inside 
                                mainfiest.json to indicate the physical 
                                location of that file.
  --cleanupCacheHistory         If set to true, docfx create a new intermediate
                                folder for cache files, historical cache data 
                                will be cleaned up
  --falName                     Set the name of input file abstract layer 
                                builder.
  --disableGitFeatures          Disable fetching Git related information for 
                                articles. By default it is enabled and may have
                                side effect on performance when the repo is 
                                large.
  --schemaLicense               Please provide the license key for validating 
                                schema using NewtonsoftJson.Schema here.
  -l, --log                     Specify the file name to save processing log
  --logLevel                    Specify to which log level will be logged. By 
                                default log level >= Info will be logged. The 
                                acceptable value could be Verbose, Info, 
                                Warning, Error.
  --repositoryRoot              Specify the GIT repository root folder.
  --correlationId               Specify the correlation id used for logging.
  --warningsAsErrors            Specify if warnings should be treated as 
                                errors.
`