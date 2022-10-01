
export type ApiCmd<A0,A1 = null, A2 = null> ={
    a0:A0
    a1?:A1
    a2?:A2
}

type files = 'files'
export type CopyFiles = ApiCmd<files,'copy'>
