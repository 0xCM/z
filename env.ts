export type SlnId = 'z0'
export type DevRoot = `d:/dev`
export type SlnRoot = `${DevRoot}/${SlnId}`
export function parent() : SlnRoot {
    return 'd:/dev/z0'
}