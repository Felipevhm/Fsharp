module WithServer.Server.Index

open Bolero
open Bolero.Html
open Bolero.Server.Html
open WithServer



let page = doctypeHtml {
    head {
        meta { attr.charset "UTF-8" }
        meta { attr.name "viewport"; attr.content "width=device-width, initial-scale=1.0" }
        title { "Bolero Application" }
        ``base`` { attr.href "/" }
        link { attr.rel "stylesheet"; attr.href "https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.4/css/bulma.min.css" }
        link { attr.rel "stylesheet"; attr.href "css/index.css" }
        link { attr.rel "stylesheet"; attr.href "WithServer.Client.styles.css" }
    }

    let someDiv = doctypeHtml {        
                div {
                attr.id( "example-div"); 
                attr.title("Example title");
                    button {
                            attr.id( "example-button")
                            attr.style("
                                        width:100%; 
                                        background-color: #3EC137;
                                        font-weight:bold")
                            "ONE GREAT hello from btn"}
                        }
    
    }

    body {
        nav {
            attr.``class`` "navbar is-dark"
            "role" => "navigation"
            attr.aria "label" "main navigation"
            div {
                attr.``class`` "navbar-brand"
                a {
                    attr.``class`` "navbar-item has-text-weight-bold is-size-5"
                    attr.href "https://fsbolero.io"
                    img { attr.style "height:40px"; attr.src "https://github.com/fsbolero/website/raw/master/src/Website/img/wasm-fsharp.png";}
                    "  Bolero"
                }
            }
        }
        someDiv
        div { attr.id "main"; comp<Client.Main.MyApp> }
        boleroScript
    }
}
