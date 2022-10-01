export * from "./cmd"
export * from "./digital"
export * from "./expr"
export * as FS from "./fs"
export * from "./graphs"
export * from "./integers"
export * from "./nats"
export * from "./symbols"
export * from "./uri"
export * from "./common"
export * from "./tools"
export * as Tk from "./tokens"
export * as Wf from "./wf"
export * from "./literals"
export * from "../core/env"
export * from "../core/bind"
export type ModuleList = Array<string>

export type Folder<P extends string> = `${P}`

export function folder<P extends string>(path:P) : Folder<P> {
    return `${path}`
}

export type Script = string

export type Kvp<K,V> = {
    key:K
    value:V
}

export type KeyedValues<K,V> = Array<Kvp<K,V>>

export type Lookup<K,V> = Map<K,V>

export function kvp<K,V>(key:K,value:V) {
    return {
        key,
        value
    }
}

export function lookup<K,V>(src?:KeyedValues<K,V>) : Lookup<K,V> {
    var dst = Map.prototype
    if(src != null)
    {
        src.forEach(kvp => {
            dst.set(kvp.key, kvp.value)
        });
    }
    return dst;
}

export function oneof<A,B,C=null>(a:A,b:B,c?:C) {    
    var dst = `${a}|${b}`
    if(c != null)
        dst += `|${c}`
    return dst
}
