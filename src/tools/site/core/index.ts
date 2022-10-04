export * from "./cmd"
export * from "./digital"
export * from "./expr"
export * from "./fs"
export * as FS from "./fs"
export * from "./nats"
export * from "./symbols"
export * from "./uri"
export * from "./common"
export * from "./tools"
export * as Tk from "./tokens"
export * as Wf from "./wf"
export * from "./literals"
export * from "./vars"
export * from "./context"
export * from "./lookup"

export type ModuleList = Array<string>


export type Script = string

export function oneof<A,B,C=null>(a:A,b:B,c?:C) {    
    var dst = `${a}|${b}`
    if(c != null)
        dst += `|${c}`
    return dst
}
