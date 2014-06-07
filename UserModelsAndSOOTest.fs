module UserModelsTest

open NUnit.Framework
open Swensen.Unquote

open Helpers
open UserModels
open Newtonsoft.Json
open TestConfiguration

[<Test>]
let ``User Models Serialize and Deserialize Properly``() =
    test <@ let baseurl = "https://auth.xamarin.com"
            let ssoToken = "0c833t3w37jq58dj249dt675a465k6b0rz090zl3jpoa9jw8vz7y6awpj5ox0qmb"
            
            let client = Xamarin.SSO.Client.XamarinSSOClient(ssoToken)
            let token = client.CreateToken(email, password)
            let fsClient = XamarinSSOClient.XamarinSSOClient (baseurl, ssoToken)
            let fstoken = fsClient.CreateToken email password |> Async.RunSynchronously
            
            match fstoken with
            | Success fstoken -> (token.Success = fstoken.Success) 
                                 && (token.User.Email = fstoken.User.Email) 
                                 && (token.User.FirstName = fstoken.User.FirstName) 
                                 && (token.User.LastName = fstoken.User.LastName) 
            | Failure fail -> false @>