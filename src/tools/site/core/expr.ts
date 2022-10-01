export type Expr<T> = {
    eval: () => T
}

export type UnaryExpr<A,B> = {
    a:A
    eval:() => B
}


export type BinaryExpr<A,B,C> = {
    a:A
    b:B
    eval: () => C
}

export type TernaryExpr<A,B,C,D> = {
    a:A
    b:B
    c:C
    eval: () => D
}


export type UnaryOperator<T> = UnaryExpr<T,T>

export type BinaryOperator<T> = BinaryExpr<T,T,T>

export type TernaryOperator<T> = TernaryExpr<T,T,T,T>

