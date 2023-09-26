// For more information see https://aka.ms/fsharp-console-apps
open System
open System.Collections.Generic

let board = Dictionary<string, bool>()

for x = 1 to 10 do
    for y = 1 to 10 do
        let x_letter = 
            if x = 1 then "A"
            elif x = 2 then "B"
            elif x = 3 then "C"
            elif x = 4 then "D"
            elif x = 5 then "E"
            elif x = 6 then "F"
            elif x = 7 then "G"
            elif x = 8 then "H"
            elif x = 9 then "I"
            elif x = 10 then "J"
            else invalidArg "letter" (sprintf "Invalid index %d used." x)
        let key = sprintf "%s%d" x_letter y
        board.Add(key, false)

printfn "The Battleship Board: %A" board

let mutable battleship_x = System.Random().Next(1,11)
let mutable battleship_y = System.Random().Next(1,11)
let battleship_orientation = System.Random().Next(1, 5) //1 - North, 2 - East, 3 - South, 4 - West

if battleship_orientation = 1 && battleship_y - 5 < 1 then
    while battleship_y - 5 < 1 do battleship_y <- battleship_y + 1

if battleship_orientation = 4 && 10 - battleship_y > 5 then
    while 10 - battleship_y > 5 do battleship_y <- battleship_y - 1

if battleship_orientation = 2 && 10 - battleship_x > 5 then
    while 10 - battleship_x > 5 do battleship_x <- battleship_x - 1

if battleship_orientation = 3 && battleship_x - 5 < 1 then
    while battleship_x - 5 < 1 do battleship_x <- battleship_x + 1

for i = 0 to 4 do
    let letter = 
            if battleship_x = 1 then "A"
            elif battleship_x = 2 then "B"
            elif battleship_x = 3 then "C"
            elif battleship_x = 4 then "D"
            elif battleship_x = 5 then "E"
            elif battleship_x = 6 then "F"
            elif battleship_x = 7 then "G"
            elif battleship_x = 8 then "H"
            elif battleship_x = 9 then "I"
            elif battleship_x = 10 then "J"
            else invalidArg "letter" (sprintf "Invalid index %d used." battleship_x)

    let battleship_coord = sprintf "%s%d" letter battleship_y
    board.[battleship_coord] <- true
    let temp = board.[battleship_coord]
    printfn "The value at %s is: %b" battleship_coord temp 
    if battleship_orientation = 1 then battleship_y <- battleship_y - 1
    elif battleship_orientation = 2 then battleship_x <- battleship_x + 1
    elif battleship_orientation = 3 then battleship_x <- battleship_x - 1
    elif battleship_orientation = 4 then battleship_y <- battleship_y + 1

let mutable destroyer1_x = System.Random().Next(1,11)
let mutable destroyer1_y = System.Random().Next(1,11)
let destroyer1_orientation = System.Random().Next(1, 5) //1 - North, 2 - East, 3 - South, 4 - West

if destroyer1_orientation = 1 && destroyer1_y - 4 < 1 then
    while destroyer1_y - 4 < 1 do destroyer1_y <- destroyer1_y + 1

if destroyer1_orientation = 4 && 10 - destroyer1_y > 6 then
    while 10 - destroyer1_y > 6 do destroyer1_y <- destroyer1_y - 1

if destroyer1_orientation = 2 && 10 - destroyer1_x > 6 then
    while 10 - destroyer1_x > 6 do destroyer1_x <- destroyer1_x - 1

if destroyer1_orientation = 3 && destroyer1_x - 4 < 1 then
    while destroyer1_x - 4 < 1 do destroyer1_x <- destroyer1_x + 1

for i = 0 to 3 do
    let letter = 
            if destroyer1_x = 1 then "A"
            elif destroyer1_x = 2 then "B"
            elif destroyer1_x = 3 then "C"
            elif destroyer1_x = 4 then "D"
            elif destroyer1_x = 5 then "E"
            elif destroyer1_x = 6 then "F"
            elif destroyer1_x = 7 then "G"
            elif destroyer1_x = 8 then "H"
            elif destroyer1_x = 9 then "I"
            elif destroyer1_x = 10 then "J"
            else invalidArg "letter" (sprintf "Invalid index %d used." destroyer1_x)

    let destroyer1_coord = sprintf "%s%d" letter destroyer1_y
    board.[destroyer1_coord] <- true
    let temp = board.[destroyer1_coord]
    printfn "The value at %s is: %b" destroyer1_coord temp 
    if destroyer1_orientation = 1 then destroyer1_y <- destroyer1_y - 1
    elif destroyer1_orientation = 2 then destroyer1_x <- destroyer1_x + 1
    elif destroyer1_orientation = 3 then destroyer1_x <- destroyer1_x - 1
    elif destroyer1_orientation = 4 then destroyer1_y <- destroyer1_y + 1
    
let destroyer2 =
    Map.empty
    |> Map.add "Point 1" true
    |> Map.add "Point 2" true
    |> Map.add "Point 3" true
    |> Map.add "Point 4" true


