import {Drive} from "./fs"

export type Scheme =
    | 'http'
    | 'file'
    | 'cmd'
    | 'app'
    | 'tool'
    | 'lang'
    | 'sdk'

// file://localhost/c:/WINDOWS/clock.avi
// file:///c:/WINDOWS/clock.avi
// authority = [userinfo "@"] host [":" port]
// URI = scheme ":" ["//" authority] path ["?" query] ["#" fragment]
export type UriScheme<S extends Scheme> = S

export type Resource<N,K,P> = {
    name:N
    kind:K
    path:P
}

export type UriPort<P extends number> = P

export type UriHost<H> = H

export type Fragment<F> = F

export type UriPath<U> = U

export type Authority<H,P extends number> = {
    userinfo:string
    host:UriHost<H>
    port:UriPort<P>    
}

export type UriQuery<Q,F> = {
    query:Q
    fragment:Fragment<F>
}

export type Uri<S extends Scheme,P extends number, H, A, Q, U, F> ={
    scheme:UriScheme<S>
    authority?:Authority<A,P>
    port?:UriPort<P>
    host:UriHost<H>
    path:UriPath<U>
    query?:UriQuery<Q,F>
}

export type FileUri<U, H="localhost", Q=null, F=null> = {
    scheme:UriScheme<"file">
    host:UriHost<H>
    path:UriPath<U>
    query?:UriQuery<Q,F>
}

// URI = scheme ":" ["//" authority] path ["?" query] ["#" fragment]
// https://en.wikipedia.org/wiki/Uniform_Resource_Identifier
export type LocalResource<S extends Scheme, N extends string, D extends Drive, R extends string> = {
    scheme:S
    name:N
    drive:D
    root:R
    uri:() => `${S}://${D}/${R}/${N}`
}
