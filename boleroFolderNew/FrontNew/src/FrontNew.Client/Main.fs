module FrontNew.Client.Main

open System
open System.Net.Http
open System.Net.Http.Json
open Microsoft.AspNetCore.Components
open Elmish
open Bolero
open Bolero.Html

/// Routing endpoints definition. 
type Page =
    | [<EndPoint "/">] Home
    | [<EndPoint "/counter">] Counter
    | [<EndPoint "/data">] Data

/// The Elmish application's model.
type Model =
    {
        page: Page
        counter: int
        books: Book[] option
        error: string option
        textOut: string
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
        textOut = ""
    }


/// The Elmish application's update messages.
type Message =
    | SetPage of Page
    | Increment
    | Decrement
    
    | PressedA
    | PressedB
    | PressedC 
    // | StringHandler of string

    | SetCounter of int
    | GetBooks
    | GotBooks of Book[]
    | Error of exn
    | ClearError

let update (http: HttpClient) message model =
    match message with
    | SetPage page ->
        { model with page = page }, Cmd.none

    | PressedA ->
        { model with textOut = "A" }, Cmd.none
    | PressedB ->
        { model with textOut = "B" }, Cmd.none
    | PressedC ->
        { model with textOut = "C" }, Cmd.none 

    // | StringHandler  passedText ->
    //     { model with textOut = passedText }, Cmd.none
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

let counterPage model dispatch =
    Main.Counter()
        .Decrement(fun _ -> dispatch Decrement)
        .Increment(fun _ -> dispatch Increment)

        .PressedA(fun _ -> dispatch PressedA)
        .PressedB(fun _ -> dispatch PressedB)
        .PressedC(fun _ -> dispatch PressedC)
        // .CallHandler("A", fun passedText -> dispatch (StringHandler passedText))
        .TheText(model.textOut)

        .Value(model.counter, fun v -> dispatch (SetCounter v))
        .Elt()

let dataPage model dispatch =
    Main.Data()
        .Reload(fun _ -> dispatch GetBooks)
        .Rows(cond model.books <| function
            | None ->
                Main.EmptyData().Elt()
            | Some books ->
                forEach books <| fun book ->
                    tr {
                        td { book.title }
                        td { book.author }
                        td { book.publishDate.ToString("yyyy-MM-dd") }
                        td { book.isbn }
                    })
        .Elt()


let view model dispatch =
    Main()
        .Body(
            cond model.page <| function
            | Home -> counterPage model dispatch
        )
        .Error(
            cond model.error <| function
            | None -> empty() 
            | Some err ->
                Main.ErrorNotification()
                    .Text(err)
                    .Hide(fun _ -> dispatch ClearError)
                    .Elt()
        )
        .Elt()

type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override _.CssScope = CssScopes.MyApp

    [<Inject>]
    member val HttpClient = Unchecked.defaultof<HttpClient> with get, set

    override this.Program =
        let update = update this.HttpClient
        Program.mkProgram (fun _ -> initModel, Cmd.ofMsg GetBooks) update view
        |> Program.withRouter router
