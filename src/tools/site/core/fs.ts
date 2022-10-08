import { EmptyString, Null } from "./common"
import {FSlash,BSlash} from "./tokens"
import {Link} from "./links"
import {Literal} from "./literals"
import { Kinded } from "./kinds"

export type PathSep = EmptyString | BSlash | FSlash

export function sep(kind:PathSep) {
    var sep :PathSep = ''
    switch(kind)
    {
        case '/':
            sep = '/'
        break;
        case '\\':
            sep = '\\'
        break;
    }
    return `${sep}`
}


export type DriveLetter = 
    | ''
    | `A:` 
    | 'B:' 
    | 'C:' 
    | 'D:' 
    | 'E:' 
    | 'F:' 
    | 'G:' 
    | 'H:' 
    | 'I:' 
    | 'J:' 
    | 'K:' 
    | 'L:' 
    | 'M:' 
    | 'N:' 
    | 'N:' 
    | 'O:'
    | 'P:'
    | 'Q:'
    | 'R:'
    | 'S:'
    | 'T:'
    | 'U:' 
    | 'V:' 
    | 'W:'
    | 'X:'
    | 'Y:'
    | 'Z:'

export type Drive<K extends DriveLetter> = K
    
export type Volume<V> = V

export type Mount<P,R> = {
        protocol:P
        root:R
    }
    
export type WslMount<M> = Mount<`\\\\wsl$`,M>

export type NtfsMount<P extends DriveLetter,R> = Mount<P,R>


export enum ObjectKind  {
    None,

    Folder,

    File,

    Drive,
}


export interface File<L extends Literal> extends Kinded<ObjectKind>{
    location:L    
}


// export function file<F extends Literal>(file:F) : File<F> {
//     return file
// }

export interface Folder<L extends Literal> extends Kinded<ObjectKind> {
    location:L
}

export type Object<L extends Literal> = Folder<L> | File<L> | DriveLetter


export interface Path<L extends Literal> extends Link<ObjectKind,Object<L>> {

} 



//Link<Folder<P> | File<P>>


export function path<K,P extends Literal>(kind:ObjectKind, source:Object<P>, target:Object<P>) : Path<P> {
     return {
        kind,
        source,
        target,
     }
 }

export function folder<L extends Literal>(location:L) : Folder<L> {
    return {
        kind:ObjectKind.Folder,
        location
    }
}

export function file<L extends Literal>(location:L) : File<L> {
    return {
        kind:ObjectKind.Folder,
        location
    }
}


export type Symlink<F extends Literal> = Link<ObjectKind,Path<F>>