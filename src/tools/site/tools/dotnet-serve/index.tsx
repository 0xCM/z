import {Actor,Number,Numeric,Literal,Tk} from "../imports"
export type Name = `dotnet-serve`
export function Name() : Name {
    return 'dotnet-serve'
}
export type Tool = Actor<Name>
export type Port<P extends Number> = Numeric<P>
export type Dir<D extends Literal> = D
export type Open='-o'
export type DefaultExtensions = '--default-extensions'

export type Syntax<D extends Literal,P extends Number> 
    = `${Name} -d ${Dir<D>} -o --port ${Port<P>} ${DefaultExtensions}:txt --${Tk.Mime} .${Tk.Csv}=text/plain`

export function syntax<D extends Literal,P extends Number>(dir:D,port:P) : Syntax<D,P>{
    return `${Name()} -d ${dir} -o --port ${port} --default-extensions:txt --mime .csv=text/plain`
    }
    
export const HelpDocs =[
    `Usage: dotnet serve [options]

    Options:
      --version                            Show version information.
      -d|--directory <DIR>                 The root directory to serve. [Current directory]
      -o|--open-browser                    Open a web browser when the server starts. [false]
      -p|--port <PORT>                     Port to use [8080]. Use 0 for a dynamic port.
      -a|--address <ADDRESS>               Address to use [127.0.0.1]
      --path-base <PATH>                   The base URL path of postpended to the site url.
      --reverse-proxy <MAPPING>            Map a path pattern to another url.
                                           Expected format is <SOURCE_PATH_PATTERN>=<DESTINATION_URL_PREFIX>.
                                           SOURCE_PATH_PATTERN uses ASP.NET routing syntax. Use {**all} to match anything.
      --default-extensions[:<EXTENSIONS>]  A comma-delimited list of extensions to use when no extension is provided in the URL. [.html,.htm]
      -q|--quiet                           Show less console output.
      -v|--verbose                         Show more console output.
      -h|--headers <HEADER_AND_VALUE>      A header to return with all file/directory responses. e.g. -h "X-XSS-Protection: 1; mode=block"
      -S|--tls                             Enable TLS (HTTPS)
      --cert                               A PEM encoded certificate file to use for HTTPS connections.
                                           Defaults to file in current directory named 'cert.pem'
      --key                                A PEM encoded private key to use for HTTPS connections.
                                           Defaults to file in current directory named 'private.key'
      --pfx                                A PKCS#12 certificate file to use for HTTPS connections.
                                           Defaults to file in current directory named 'cert.pfx'
      --pfx-pwd                            The password to open the certificate file. (Optional)
      -m|--mime <MAPPING>                  Add a mapping from file extension to MIME type. Empty MIME removes a mapping.
                                           Expected format is <EXT>=<MIME>.
      -z|--gzip                            Enable gzip compression
      -b|--brotli                          Enable brotli compression
      -c|--cors                            Enable CORS (It will enable CORS for all origin and all methods)
      --save-options                       Save specified options to .netconfig for subsequent runs.
      --config-file                        Use the given .netconfig file.
      -?|--help                            Show help information.
    
    `
]