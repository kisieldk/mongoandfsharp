// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
open Microsoft.FSharp.Data.TypeProviders
open MongoDB.Bson
open MongoDB.Bson.Serialization
open MongoDB.Driver
open MongoDB.Bson.IO
//For fun
//let cos = (fun x y -> x*y)
//let lista = ["adam";"ewa";"rychu";"peja"]
//

///Connecting to MongoDb example
let conStrin ="constringToDb"
let client = MongoClient(conStrin)
let db =client.GetDatabase("mt") 

let doc = BsonDocument()
let a = BsonValue.Create("Mistrzem poliki")
let bosEle = BsonElement("Legi jest",a)
doc.Add bosEle |> ignore
let coll = db.GetCollection<BsonDocument>("kolekcja")


[<EntryPoint>]
let main argv = 
    printfn "Hello, world!"
    //coll.InsertOne(doc)
    printfn "Dodałem frajera"
    let a =query {
            for x in coll.AsQueryable<BsonDocument>() do
                select x }
        |> Seq.toArray
    for i in a do
        Console.WriteLine(i.GetElement(1).Name + " " +   i.GetValue(1).ToString())
   
//    let a = cos 2 2 
//    for i in lista do
//        let fffff = i
//        printfn "Z Listy %s" fffff
//    printfn "Z funkcji %i" a
    Console.Read() 
    |> ignore 
    0
