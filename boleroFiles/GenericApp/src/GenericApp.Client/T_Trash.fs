  body { 
        nav { 
            attr.`class` "navbar is-dark" 
            "role" => "navigation" 
            attr.aria "label" "main navigation" 
            div { 
                attr.`class` "navbar-brand" 
                a { 
                    attr.`class` "navbar-item has-text-weight-bold is-size-5" 
                    attr.href "https://fsbolero.io" 
                    img { attr.style "height:40px"; attr.src "https://github.com/fsbolero/website/raw/master/src/Website/img/wasm-fsharp.png" } 
                    "  Bolero" 
                } 
            } 
        } 
        div { attr.id "main"; comp<Client.Main.MyApp> } 
        boleroScript 
    }