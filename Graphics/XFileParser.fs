namespace DemoApplication.Graphics

open System
open System.IO

open DemoApplication.Mathematics
open System


//let mutable status:String = "test"

type XFileParser public (filePath:string) =
    
    let mutable polygon:Polygon = new Polygon(0,0,0,0)

    do
        if File.Exists(filePath) then 
            let lines = File.ReadAllLines(filePath) |> Array.toList
            //Console.WriteLine("Viewing the model of {0} and the first string is {1}", filePath, lines.Item(4))

            
            let searchingString = "Mesh {"
            
            //so we try to find an element in lines where this^ function returns true
            //let result = List.find (stringContains "Mesh {") lines
            //Console.WriteLine("result: {0}", result)

            //let verticeCountLine:int32 = (List.findIndex(stringContains "Mesh {") lines) + 1
            
            //this all works, I can find the number in each of the groups and pull the number. Just need to parse the actual numbers and input it into a polygon
            let stringContains (passedString:string) (currentElement:string) = currentElement.Contains(passedString) // = true

            let vertCountLocation:int32 = (List.findIndex(stringContains "Mesh {") lines) + 1
            let verticeCount:int32 = Int32.Parse( lines.Item( vertCountLocation ).Replace(";","") )
            Console.WriteLine("Vert Count is: {0}", verticeCount) 

            //verticeGroupCount will be after all of the vertices in the mesh
            let verticeGroupCount:int32 = Int32.Parse( lines.Item( vertCountLocation + verticeCount + 1).Replace(";","") )
            Console.WriteLine("Vert group Count is: {0}", verticeGroupCount)

            let normalCountLocation:int32 = (List.findIndex(stringContains "MeshNormals {") lines) + 1
            let normalCount:int32 = Int32.Parse( lines.Item( normalCountLocation ).Replace(";","") )
            Console.WriteLine("Normal Count is: {0}", normalCount) 

            let normalGroupCount:int32 = Int32.Parse( lines.Item( normalCountLocation + normalCount + 1).Replace(";","") )
            Console.WriteLine("Normal group Count is: {0}", normalGroupCount)


            
            let formattedLine:string = lines.Item(vertCountLocation + 1).Replace(",","")
            let formattedLine2:string = formattedLine.Replace(" ","")
            let split = formattedLine2.Split ';'
            
            let line1Vector = new Vector3(float32 split.[0], float32 split.[1], float32 split.[2])

            let mutable currentLine = 0
            
            Console.WriteLine(line1Vector.x)

            Console.WriteLine("First Line of mesh is: {0}", formattedLine);

            //create the polygon with the correct counts 
            polygon <- new Polygon(verticeCount, verticeGroupCount, normalCount, normalGroupCount)

            //add the vertices
            for i = 1 to verticeCount do
                let formattedLine:string = lines.Item(vertCountLocation + i).Replace(",","")
                let formattedLine2:string = formattedLine.Replace(" ","")
                let split = formattedLine2.Split ';'
 
                let currentVector = new Vector3(float32 split.[0], float32 split.[1], float32 split.[2])
                polygon.Vertices.Add(currentVector)
            
            //add the normals
            for i = 1 to normalCount do
                let formattedLine:string = lines.Item(normalCountLocation + i).Replace(",","")
                let formattedLine2:string = formattedLine.Replace(" ","")
                let split = formattedLine2.Split ';'
 
                let currentVector = new Vector3(float32 split.[0], float32 split.[1], float32 split.[2])
                polygon.Normals.Add(currentVector)
            
            //now I just need to add the array things, probably will figure out how to do that tomorrow

            for i = 1 to verticeGroupCount do
                (* I first need to get the number of things in the vert group. For the square, there are 
                4 because they are squares, but the Icosphere has 3.
                The format should dictate that the first number (numbers until a semicolon) is the number 
                items in the group. 
                *)
                //Get that number. If we split based on ; first, the first number should be the correct number.
                let correctLine:string = lines.Item(vertCountLocation + verticeCount + 1 + i)
                let firstSplit = correctLine.Split ';'
                //Console.WriteLine("The number of items in this group is: {0}", firstSplit.[0])
                //Console.WriteLine("# items in firstSplit {0}", firstSplit.Length)
                let splitOfMiddleSection = firstSplit.[1].Split ','
                //let mutable arrayToAdd = [||]
                let arrayToAdd : int array = Array.zeroCreate splitOfMiddleSection.Length
                for j = 0 to splitOfMiddleSection.Length - 1 do
                    //Console.WriteLine(splitOfMiddleSection.[j])
                    arrayToAdd.[j] <- int splitOfMiddleSection.[j]
                    //Console.WriteLine(arrayToAdd.[j])
                polygon.VerticeGroups.Add(arrayToAdd)

            for i = 1 to normalGroupCount do
                (* I first need to get the number of things in the vert group. For the square, there are 
                4 because they are squares, but the Icosphere has 3.
                The format should dictate that the first number (numbers until a semicolon) is the number 
                items in the group. 
                *)
                //Get that number. If we split based on ; first, the first number should be the correct number.
                let correctLine:string = lines.Item(normalCountLocation + normalCount + 1 + i)
                let firstSplit = correctLine.Split ';'
                //Console.WriteLine("The number of items in this group is: {0}", firstSplit.[0])
                //Console.WriteLine("# items in firstSplit {0}", firstSplit.Length)
                let splitOfMiddleSection = firstSplit.[1].Split ','
                //let mutable arrayToAdd = [||]
                let arrayToAdd : int array = Array.zeroCreate splitOfMiddleSection.Length
                for j = 0 to splitOfMiddleSection.Length - 1 do
                    //Console.WriteLine(splitOfMiddleSection.[j])
                    arrayToAdd.[j] <- int splitOfMiddleSection.[j]
                    //Console.WriteLine(arrayToAdd.[j])
                polygon.NormalGroups.Add(arrayToAdd)


                //let formattedLine:string = lines.Item(vertCountLocation + verticeCount + 1 + i ).Replace(",","")
                //let formattedLine2:string = formattedLine.Replace(" ","")
                //let newSplit = formattedLine2.Split ';'

                //Console.WriteLine("First split is {0}", split.[0])
                //Console.WriteLine("The whole split is {0}", split.ToString())

                //let verticeGroupArray = [|int32 split.[0]; int32 split.[1]; int32 split.[2]; int32 split.[3]|]
                //testPrimitive.VerticeGroups.Add(verticeGroupArray)


            let verticeGroupArray = [|0; 1; 5; 4;|]

            Console.WriteLine(verticeGroupArray)

            //testPrimitive.Vertices.Add(line1Vector)
            Console.WriteLine("set a debug point here to check out your polygon")





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
    
    member public this.ReturnReadPolygon() : Polygon = 
        polygon
    
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
        


