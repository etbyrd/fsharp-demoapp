namespace DemoApplication.Graphics

open System
open System.IO

open DemoApplication.Mathematics


//let mutable status:String = "test"

type XFileParser public (filePath:string) =
    
    do
        if File.Exists(filePath) then 
            let lines = File.ReadAllLines(filePath) |> Array.toList
            //Console.WriteLine("Viewing the model of {0} and the first string is {1}", filePath, lines.Item(4))

            let mutable currentLine = 0
            let searchingString = "Mesh {"
            
            //so we try to find an element in lines where this^ function returns true
            //let result = List.find (stringContains "Mesh {") lines
            //Console.WriteLine("result: {0}", result)

            //let verticeCountLine:int32 = (List.findIndex(stringContains "Mesh {") lines) + 1
            
            let stringContains (passedString:string) (currentElement:string) = currentElement.Contains(passedString) // = true
            let verticeCount:int32 = Int32.Parse( lines.Item( (List.findIndex(stringContains "Mesh {") lines) + 1 ).Replace(";","") )
            Console.WriteLine("Vert Count is: {0}", verticeCount) 





            (*
            for line in lines do
                if line.Contains("Mesh {") then
                    Console.WriteLine("compare: {0}", String.Compare("Mesh {", line))
                    let meshNumber = lines.Item(currentLine + 1).Replace(";","")
                    Console.WriteLine("Vertice count is {0}", meshNumber)
                    
                
                currentLine <- currentLine + 1
            *)
        else
            Console.WriteLine("Model file not found, check the filepath")
        
        
        

    member public this.Info() =
        Console.WriteLine(filePath)
    
    member public this.ReturnPrimitive() : Polygon = 
        let primitive:Polygon = new Polygon(8, 6, 6, 6)

        //primitive.verti
    
        primitive.Vertices.Add(new Vector3(-1.000000f, -1.000000f, -1.000000f))
        primitive.Vertices.Add(new Vector3(-1.000000f,  1.000000f, -1.000000f))
        primitive.Vertices.Add(new Vector3( 1.000000f,  1.000000f, -1.000000f))
        primitive.Vertices.Add(new Vector3( 1.000000f, -1.000000f, -1.000000f))
        primitive.Vertices.Add(new Vector3(-1.000000f, -1.000000f,  1.000000f))
        primitive.Vertices.Add(new Vector3(-1.000000f,  1.000000f,  1.000000f))
        primitive.Vertices.Add(new Vector3( 1.000000f,  1.000000f,  1.000000f))
        primitive.Vertices.Add(new Vector3( 1.000000f, -1.000000f,  1.000000f))

        primitive.VerticeGroups.Add([| 0; 1; 5; 4 |])
        primitive.VerticeGroups.Add([| 1; 2; 6; 5 |])
        primitive.VerticeGroups.Add([| 2; 3; 7; 6 |])
        primitive.VerticeGroups.Add([| 3; 0; 4; 7 |])
        primitive.VerticeGroups.Add([| 3; 2; 1; 0 |])
        primitive.VerticeGroups.Add([| 4; 5; 6; 7 |])

        primitive.Normals.Add(new Vector3(-1.000000f,  0.000000f,  0.000000f))
        primitive.Normals.Add(new Vector3( 0.000000f,  1.000000f, -0.000000f))
        primitive.Normals.Add(new Vector3( 1.000000f,  0.000000f, -0.000000f))
        primitive.Normals.Add(new Vector3( 0.000000f, -1.000000f,  0.000000f))
        primitive.Normals.Add(new Vector3(-0.000000f,  0.000000f, -1.000000f))
        primitive.Normals.Add(new Vector3(-0.000000f,  0.000000f,  1.000000f))

        primitive.NormalGroups.Add([| 0; 0; 0; 0 |])
        primitive.NormalGroups.Add([| 1; 1; 1; 1 |])
        primitive.NormalGroups.Add([| 2; 2; 2; 2 |])
        primitive.NormalGroups.Add([| 3; 3; 3; 3 |])
        primitive.NormalGroups.Add([| 4; 4; 4; 4 |])
        primitive.NormalGroups.Add([| 5; 5; 5; 5 |])

        primitive

//    member private this.Parse() =
        


