module GravatarTest

open NUnit.Framework
open Swensen.Unquote

open Helpers
open TestConfiguration

[<Test>]
let ``Gravatar Test``() =
    test <@ let csdata = async {
                            try 
                                return! XamarinStore.Gravatar.GetImageBytes(email, 60) |> Async.AwaitTask
                            with
                                | e-> return [||] } 
                         |> Async.RunSynchronously
            let fsdata = async {
                             return! Gravatar.GetImageBytes email 60 Gravatar.Rating.G
                         } |> Async.RunSynchronously
            fsdata = csdata @>