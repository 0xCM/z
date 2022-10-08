export function oneof<A,B,C=null>(a:A,b:B,c?:C) {    
    var dst = `${a}|${b}`
    if(c != null)
        dst += `|${c}`
    return dst
}
