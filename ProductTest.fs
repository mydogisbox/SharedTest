module ProductTest

open NUnit.Framework
open Swensen.Unquote

open WebService
open Helpers
open Product

let productSize = { ProductSize.Name="Name"; Description="Description" }
let productSize2 = { ProductSize.Name="Name"; Description="Description2" }
let productSize3 = { ProductSize.Name="Name2"; Description="Description" }

[<Test>]
let ``ProductSize Equality Test``() =
    test <@ productSize=productSize2 @>
    test <@ not (productSize=productSize3) @>

[<Test>]
let ``ProductSize Name Test``() =
    test <@ productSize.ToString() = "Description" @>

[<Test>]
let ``ImageUrl Test``() =
    let fsProduct = { Product.Price = 0.0
                      Size = { Name = ""
                               Description=""}
                      Color = { Name="Test"
                                ImageUrls=[||] }
                      ProductType=1
                      Name = ""
                      Description = ""
                      Colors=[|{ Name="Test"
                                 ImageUrls=[|"Test"|] }|]
                      Sizes = [||] }

    let csProduct = new XamarinStore.Product(Price = 0.0, 
                                             Size=XamarinStore.ProductSize(), 
                                             Color=XamarinStore.ProductColor(),
                                             ProductType=XamarinStore.ProductType.MensCSharpShirt,
                                             Name="",
                                             Description = "",
                                             Colors = [|new XamarinStore.ProductColor(ImageUrls=[|"Test"|])|],
                                             Sizes = [||])
    test <@ csProduct.ImageUrl.Equals(fsProduct.GetImageUrl()) @>
    test <@ csProduct.ImageForSize(32.0f).Equals(fsProduct.ImageForSize(32.0f)) @>
    test <@ csProduct.PriceDescription.Equals(fsProduct.GetPriceDescription()) @>
    
