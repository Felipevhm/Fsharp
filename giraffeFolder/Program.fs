open System
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open Giraffe.EndpointRouting

// ---------------------------------
// Models
// ---------------------------------

type Message =
    {
        Text : string
    }
// ---------------------------------
let random = Random() // Move this line outside the function

let indexHandler (name : string) (next: HttpFunc) (ctx: HttpContext) : HttpFuncResult =

        let greetings = sprintf "Hello big %s, from Giraffe!" name
        let model     = { Text = greetings }

        json model next ctx

let randomElement(random:Random) (next: HttpFunc) (ctx: HttpContext) : HttpFuncResult=
    
    let storedList = [|"Julius Caesar"; "Apple"; "Japan"; "Elephant"; "Hercules"; "Wave"; "Nero"; "Banana"; "China"; "Lion"|]

    let index = random.Next(storedList.Length)   
    let name = storedList.[index]
    let fullMessage = sprintf "Random %i element: %s" index name
    let model     = { Text = fullMessage }
    json model next ctx

let endpoints =
    [
        GET [
            route "/" (indexHandler "root")
            route "/next-string" (warbler (fun _ ->  (randomElement(random))))
        ]
    ]

let notFoundHandler =
    "Not Found"
    |> text
    |> RequestErrors.notFound

let configureApp (appBuilder : IApplicationBuilder) =
    appBuilder
        .UseRouting()
        .UseGiraffe(endpoints)
        .UseGiraffe(notFoundHandler)

let configureServices (services : IServiceCollection) =
    services
        .AddRouting()
        .AddGiraffe()
    |> ignore

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    configureServices builder.Services

    let app = builder.Build()

    if app.Environment.IsDevelopment() then
        app.UseDeveloperExceptionPage() |> ignore
    
    configureApp app
    app.Run()

    0