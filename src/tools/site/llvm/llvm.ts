
export namespace llvm {
    export type Llvm='llvm'

    export type Include=`${Llvm}/include`

    export type Adt=`${Include}/ADT`

    function files<S>(source:S)
    {
        return [
            '',
            ''
        ]
    }

    function llvm():Llvm
    {
        return 'llvm'
    }

    function include() : Include
    {
        return `${llvm()}/include`
    }

    function adt() : Adt
    {
        return `${include()}/ADT`
    }
}

