module FrontApp.Client.Main

open System
open System.Net.Http
open System.Net.Http.Json
open Microsoft.AspNetCore.Components
open Elmish
open Bolero
open Bolero.Html

/// Routing endpoints definition.
type Page =
    | [<EndPoint "/">] Home //

/// The Elmish application's model.//
type Model =
    {
        page: Page
        counter: int
        books: Book[] option
        error: string option
    }

and Book =
    {
        title: string
        author: string
        publishDate: DateTime
        isbn: string
    }

let initModel =
    {
        page = Home
        counter = 0
        books = None
        error = None
    }


/// The Elmish application's update messages. m
type Message =
    | SetPage of Page
    | Increment
    | Decrement
    | SetCounter of int
    | GetBooks
    | GotBooks of Book[]
    | Error of exn
    | ClearError

    | NewIncrement
    | SetNewCounter

    // |Newtext of string 

let update (http: HttpClient) message model =
    match message with
    | SetPage page ->
        { model with page = page }, Cmd.none

    | NewIncrement ->
        { model with counter = model.counter + 1 }, Cmd.none

    | Increment ->
        { model with counter = model.counter + 1 }, Cmd.none
    | Decrement ->
        { model with counter = model.counter - 1 }, Cmd.none
    | SetCounter value ->
        { model with counter = value }, Cmd.none

    | GetBooks ->
        let getBooks() = http.GetFromJsonAsync<Book[]>("/books.json")
        let cmd = Cmd.OfTask.either getBooks () GotBooks Error
        { model with books = None }, cmd
    | GotBooks books ->
        { model with books = Some books }, Cmd.none

    | Error exn ->
        { model with error = Some exn.Message }, Cmd.none
    | ClearError ->
        { model with error = None }, Cmd.none

/// Connects the routing system to the Elmish application.
let router = Router.infer SetPage (fun model -> model.page)

type Main = Template<"wwwroot/main.html">

let homePage model dispatch =
    Main.Home().Elt()
let view model dispatch =
    Main()
        .Body( //
            cond model.page <| function 
            | Home -> homePage model dispatch
        )
        .Elt() //

type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override _.CssScope = CssScopes.MyApp

    [<Inject>]
    member val HttpClient = Unchecked.defaultof<HttpClient> with get, set

    override this.Program =
        let update = update this.HttpClient
        Program.mkProgram (fun _ -> initModel, Cmd.ofMsg GetBooks) update view
        |> Program.withRouter router
