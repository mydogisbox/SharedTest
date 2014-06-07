module WebServiceTest

open WebService
open TestConfiguration
open XamarinStore

open NUnit.Framework
open Swensen.Unquote


[<Test>]
let ``Get Products Test`` () = 
    let shared = XamarinStore.WebService.Shared
    let result = shared.GetProducts().Result
    ()