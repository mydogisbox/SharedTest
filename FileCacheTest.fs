module FileCacheTest

open FileCache
open TestConfiguration

open NUnit.Framework
open Swensen.Unquote

[<Test>]
let ``Hex Test`` () = 
    let fsHex10 = hex 10
    let fsHex9 = hex 9

    let csHex10 = XamarinStore.FileCache.hex 10
    let csHex9 = XamarinStore.FileCache.hex 9

    test <@ csHex10 = fsHex10 @>
    test <@ csHex9 = fsHex9 @>

[<Test>]
let ``md5 Test`` () = 
    let testString = "12346579801234567890123456789012"
    let fsmd5 = md5 testString
    let csmd5 = XamarinStore.FileCache.md5 testString
    test <@ csmd5.Equals fsmd5 @>