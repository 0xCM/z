export type Context<C> = C

export type Scope<C,S> = {
    context:Context<C>
    scope:S
}
