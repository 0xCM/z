export {}


export interface CmdName<N>{
    Name:N
}

export interface CmdKind<K>{
    Kind?:K
}

export interface CmdSpec<N,K> extends CmdName<N>, CmdKind<K> {
    /**The command intent */
    Intent?:string
}
