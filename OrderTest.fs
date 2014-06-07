module OrderTest

open NUnit.Framework
open Swensen.Unquote

open WebService
open Helpers
open Order
open User

open Newtonsoft.Json

[<Test>]
let ``Order to Json Test``() =
    let fsOrder = { Order.Products = []
                    SsoToken = "SsoToken"
                    ShippingName = "ShippingName"
                    Email = "Email"
                    Address1 = "Address1"
                    Address2 = "Address2"
                    City = "City"
                    State = "State"
                    ZipCode = "ZipCode"
                    Phone = "Phone"
                    Country = "Country"
                    Notification = None }
    let csOrder = XamarinStore.Order(SsoToken = "SsoToken",
                                     ShippingName = "ShippingName",
                                     Email = "Email",
                                     Address1 = "Address1",
                                     Address2 = "Address2",
                                     City = "City",
                                     State = "State",
                                     ZipCode = "ZipCode",
                                     Phone = "Phone",
                                     Country = "Country")

    let fsUser = User.CreateUser(FirstName = "FirstName",
                                 LastName = "LastName",
                                 Email = "Email",
                                 Token = "SsoToken",
                                 Address = "Address1",
                                 Address2 = "Address2",
                                 City = "City",
                                 State = "State",
                                 ZipCode = "ZipCode",
                                 Phone = "Phone",
                                 Country = "Country")

    let csUser = XamarinStore.User(FirstName = "FirstName",
                                   LastName = "LastName",
                                   Email = "Email",
                                   Token = "SsoToken",
                                   Address = "Address1",
                                   Address2 = "Address2",
                                   City = "City",
                                   State = "State",
                                   ZipCode = "ZipCode",
                                   Phone = "Phone",
                                   Country = "Country")

    test <@ (fsOrder.GetJson fsUser).Equals (csOrder.GetJson csUser) @>

let ``OrderResult to Json Test``() = 
    let fsOrderResult = { Message = "Message"; OrderNumber = "1"; Success = true }

    let csOrderResult = new XamarinStore.OrderResult( Success = true, OrderNumber = "1", Message = "Message")

    test <@ (fsOrderResult |> JsonConvert.SerializeObject).Equals (csOrderResult |> JsonConvert.SerializeObject) @>