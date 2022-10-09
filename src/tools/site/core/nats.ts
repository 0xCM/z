export type N0 = 0
export type N1 = 1
export type N2 = 2
export type N3 = 3
export type N4 = 4
export type N5 = 5
export type N6 = 6
export type N7 = 7
export type N8 = 8
export type N9 = 9
export type N10 = 10
export type N11 = 11
export type N12 = 12
export type N13 = 13
export type N14 = 14
export type N15 = 15
export type N16 = 16
export type N17 = 17
export type N18 = 18
export type N19 = 19
export type N20 = 20
export type N21 = 21
export type N22 = 22
export type N23 = 23
export type N24 = 24
export type N25 = 25
export type N26 = 26
export type N27 = 27
export type N28 = 28
export type N29 = 29
export type N30 = 30
export type N31 = 31
export type N32 = 32
export type N33 = 33
export type N34 = 34
export type N35 = 35
export type N36 = 36
export type N37 = 37
export type N38 = 38
export type N39 = 39
export type N40 = 40
export type N41 = 41


export type Pow2x2 = N0 | N1
export type Pow2x3 = Pow2x2 | N2
export type Pow2x4 = Pow2x3 | N3
export type Pow2x5 = Pow2x4 | N4
export type Pow2x6 = Pow2x5 | N5
export type Pow2x7 = Pow2x6 | N6
export type Pow2x8 = Pow2x7 | N7 
export type Pow2x16 = Pow2x8 | N8 |  N9 | N10 | N11 | N12 | N13 | N14 | N15 
export type Pow2x24 = Pow2x16 | N16 | N17 | N18 | N19 | N20 | N21 | N22 | N23 
export type Pow2x32 = Pow2x24 | N24 | N25 | N26 | N27 | N28 | N29 | N30 | N31
export type Pow2x40 = Pow2x32 | N32 | N33 | N34 | N35 | N36 | N37 | N38 | N39 
export type Pow2x48 = Pow2x40 | 40 | 41 | 42 | 43 | 44 | 45 | 46 | 47
export type Pow2x56 = Pow2x48 | 48 | 49 | 50 | 51 | 52 | 53 | 54 | 55
export type Pow2x64 = Pow2x56 | 56 | 57 | 58 | 59 | 60 | 61 | 62 | 63
export type Nat = Pow2x64 | 64 | 65 | 66 | 67
export type GNat<N extends Nat> = N


export type NatVal<B extends Nat> = {
    value:B
}

export function nat<B extends Nat>(value:B) : NatVal<B> {
    return {
        value
    }
}
