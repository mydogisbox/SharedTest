module ColorTest

open NUnit.Framework
open Swensen.Unquote

open Helpers

[<Test>]
let ``Color Purple Test``() =
    test <@ (XamarinStore.Color.Purple.R = Color.Purple.R) @>
    test <@ (XamarinStore.Color.Purple.G = Color.Purple.G) @>
    test <@ (XamarinStore.Color.Purple.B = Color.Purple.B) @>
    
[<Test>]
let ``Color Blue Test``() =
    test <@ (XamarinStore.Color.Blue.R = Color.Blue.R) @>
    test <@ (XamarinStore.Color.Blue.G = Color.Blue.G) @>
    test <@ (XamarinStore.Color.Blue.B = Color.Blue.B) @>
    
[<Test>]
let ``Color Dark Blue Test``() =
    test <@ (XamarinStore.Color.DarkBlue.R = Color.DarkBlue.R) @>
    test <@ (XamarinStore.Color.DarkBlue.G = Color.DarkBlue.G) @>
    test <@ (XamarinStore.Color.DarkBlue.B = Color.DarkBlue.B) @>
    
[<Test>]
let ``Color Green Test``() =
    test <@ (XamarinStore.Color.Green.R = Color.Green.R) @>
    test <@ (XamarinStore.Color.Green.G = Color.Green.G) @>
    test <@ (XamarinStore.Color.Green.B = Color.Green.B) @>
    
[<Test>]
let ``Color Gray Test``() =
    test <@ (XamarinStore.Color.Gray.R = Color.Gray.R) @>
    test <@ (XamarinStore.Color.Gray.G = Color.Gray.G) @>
    test <@ (XamarinStore.Color.Gray.B = Color.Gray.B) @>
    
[<Test>]
let ``Color Light Gray Test``() =
    test <@ (XamarinStore.Color.LightGray.R = Color.LightGray.R) @>
    test <@ (XamarinStore.Color.LightGray.G = Color.LightGray.G) @>
    test <@ (XamarinStore.Color.LightGray.B = Color.LightGray.B) @>