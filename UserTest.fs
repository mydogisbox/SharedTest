module UserTest

open NUnit.Framework
open Swensen.Unquote

open WebService
open Helpers
open User

[<Test>]
let ``User Valiadtion Test``() =
    let service = WebService()

    let baseUser = { FirstName = ""; LastName = ""; Token = ""; Email = ""; Address = ""; Address2 = ""; City = ""; State = ""; ZipCode = ""; Phone = ""; Country = "";}
    let user1 =  {baseUser with FirstName = "FirstName" }
    let user2 =  {user1    with LastName = "LastName" }
    let user3 =  {user2    with Phone = "Phone" }
    let user4 =  {user3    with Token = "Token" }
    let user5 =  {user4    with Email = "Email" }
    let user6 =  {user5    with Address = "Address" }
    let user7 =  {user6    with Address2 = "Address2" }
    let user8 =  {user7    with City = "City" }
    let user9 =  {user8    with State = "State" }
    let user10 = {user9    with ZipCode = "ZipCode" }
    let user11 = {user10   with Country = "USA" }

    test <@ (service.ValidateUser baseUser) |> Async.RunSynchronously = Failure("First name is required") @>
    test <@ User.CreateUser() = baseUser @>
    
    test <@ (service.ValidateUser user1) |> Async.RunSynchronously = Failure("Last name is required") @>
    test <@ User.CreateUser(FirstName="FirstName") = user1 @>
    
    test <@ (service.ValidateUser user2) |> Async.RunSynchronously = Failure("Phone number is required") @>
    test <@ User.CreateUser(FirstName="FirstName", LastName="LastName") = user2 @>
    
    test <@ (service.ValidateUser user3) |> Async.RunSynchronously = Failure("Address is required") @>
    test <@ User.CreateUser(FirstName="FirstName", LastName="LastName", Phone="Phone") = user3 @>
    
    test <@ (service.ValidateUser user4) |> Async.RunSynchronously = Failure("Address is required") @>
    test <@ User.CreateUser(FirstName="FirstName", LastName="LastName", Phone="Phone", Token="Token") = user4 @>
    
    test <@ (service.ValidateUser user5) |> Async.RunSynchronously = Failure("Address is required") @>
    test <@ User.CreateUser(FirstName="FirstName", LastName="LastName", Phone="Phone", Token="Token", Email="Email") = user5 @>
    
    test <@ (service.ValidateUser user6) |> Async.RunSynchronously = Failure("City is required") @>
    test <@ User.CreateUser(FirstName="FirstName", LastName="LastName", Phone="Phone", Email="Email", Token="Token", Address="Address") = user6 @>
    
    test <@ (service.ValidateUser user11) |> Async.RunSynchronously = Failure "\"State\" is not a valid state" @>
    test <@ (service.ValidateUser { user11 with State = "Iowa"} ) |> Async.RunSynchronously = Success "User is valid" @>

    