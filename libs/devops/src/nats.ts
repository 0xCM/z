export {}

export type Natural = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 | 16
export type Nat<N extends Natural> = N
export type NatValue<V extends Natural> ={
    value:V
}
