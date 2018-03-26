namespace DemoApplication.Graphics

open System
open System.IO

type LineRecord =
        | TimeRecord of DateTime
        | TimeWaitRecord of int * int * int * int * int

type XFileParser public (filePath:string) =
    
    do
        if File.Exists(filePath) then 
            let lines = File.ReadAllLines(filePath) |> Array.toList
            
            Console.WriteLine("Viewing the model of {0} and the first string is {1}", filePath, lines.Item(4))
        else
            Console.WriteLine("Model file not found, check the filepath")

    member public this.Info() =
        Console.WriteLine(filePath)

//    member private this.Parse() =
        


