// d - crie um exemplo onde você representa dados sobre algumas igrejas 
// de Florianópolis utilizando os tipos algébricos do F#. 

// Utilize tanto records como discriminated unions. 

// Escreva uma função que processa uma lista que contém instâncias dos 
// tipos algébricos que você definiu.

// Definição dos tipos algébricos

// Record para representar os detalhes de uma igreja
type Church =
    { Name : string
      Denomination : string
      Address : string
      Capacity : int }

// Discriminated union para representar o status de uma igreja
type ChurchStatus =
    | Open
    | Closed

// Exemplo de dados sobre algumas igrejas de Florianópolis
let churchesData =
    [ { Name = "Catedral Metropolitana de Florianópolis"
        Denomination = "Católica"
        Address = "Praça XV de Novembro, Centro"
        Capacity = 500 }
        ,
      Open;

      { Name = "Igreja Presbiteriana Independente"
        Denomination = "Presbiteriana"
        Address = "Rua Esteves Júnior, Centro"
        Capacity = 300 }
        ,
      Open;

      { Name = "Igreja Mundial do Poder de Deus"
        Denomination = "Neopentecostal"
        Address = "Rua Almirante Lamego, Estreito"
        Capacity = 200 },
        
      Closed
    ]

// Imprimir as informações usando %A

for a in churchesData do
        printfn "%A\n" a

