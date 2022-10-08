export type Const<T> = T

export type Null<T=null> = Const<null>

export type EmptyString = Const<''>




export type Mapper<S,T> = (src:S) => T;
