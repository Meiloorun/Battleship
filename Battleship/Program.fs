// For more information see https://aka.ms/fsharp-console-apps
open System
open System.Collections.Generic

let board = Dictionary<string, bool>()

let convertToLetter (x: int) =
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

for x = 1 to 10 do
    for y = 1 to 10 do
        let x_letter = convertToLetter(x)
        let key = sprintf "%s%d" x_letter y
        board.Add(key, false)

printfn "The Battleship Board: %A" board

let placeShip (ship_size: int, player: int) =
    if ship_size > 5 then invalidArg "ship_size" (sprintf "Ship is too big for the game, do not exceed a size of 5")
    if player > 2 || player < 1 then invalidArg "player" (sprintf "There is only Player 1 and 2")
    let mutable valid = false
    let mutable x= System.Random().Next(1,10)
    let mutable y= 
        if player = 1 then System.Random().Next(1,5)
        else System.Random().Next(6,10)
    let mutable orientation = 0

    while valid = false do 
        x <- System.Random().Next(1,10)
        y <-
            if player = 1 then System.Random().Next(1,5)
            else System.Random().Next(6,10)
        orientation <- System.Random().Next(1, 5) //1 - North, 2 - East, 3 - South, 4 - West
        printfn "Initial Coordinates: %s" (sprintf "%s%d" (convertToLetter(x)) y)

        if player = 1 then
            if orientation = 1 && y - ship_size < 1 then
                printfn "Facing North"
                while y - ship_size < 1 do y <- y + 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x)) (y-i)
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    printfn "Checking Coord %s - Value = %b" coord board[coord]
                    if i = ship_size then checking <- false
                    i <- i + 1

            if orientation = 2 && 10 - x < ship_size then
                printfn "Facing East"
                while 10 - x < ship_size do x <- x - 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x+i)) y
                    printfn "Checking Coord %s - Value = %b" coord board[coord]
                    if board[coord] = true then 
                        valid <- false 
                        checking <- false
                    else valid <- true
                    if i = ship_size then checking <- false
                    i <- i + 1
                    

            if orientation = 3 && 6 - y < ship_size then
                printfn "Facing South"
                while 6 - y < ship_size do y <- y - 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x)) (y+i)
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    printfn "Checking Coord %s - Value = %b" coord board[coord]
                    if i = ship_size then checking <- false
                    i <- i + 1
                    

            if orientation = 4 && x - ship_size < 1 then
                printfn "Facing West"
                while x - ship_size < 1 do x <- x + 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x-i)) y
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    printfn "Checking Coord %s - Value = %b" coord board[coord]
                    if i = ship_size then checking <- false
                    i <- i + 1

        else
            if orientation = 1 && y - ship_size < 5 then
                printfn "Facing North"
                while y - ship_size < 5 do y <- y + 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x)) (y-i)
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    printfn "Checking Coord %s - Value = %b" coord board[coord]
                    if i = ship_size then checking <- false
                    i <- i + 1

            if orientation = 2 && 10 - x < ship_size then
                printfn "Facing East"
                while 10 - x < ship_size do x <- x - 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x+i)) y
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    printfn "Checking Coord %s - Value = %b" coord board[coord]
                    if i = ship_size then checking <- false
                    i <- i + 1
                

            if orientation = 3 && 10 - y < ship_size then
                printfn "Facing South"
                while 10-y < ship_size do y <- y - 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x)) (y+i)
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    printfn "Checking Coord %s - Value = %b" coord board[coord]
                    if i = ship_size then checking <- false
                    i <- i + 1
                

            if orientation = 4 && x - ship_size < 1 then
                printfn "Facing East"
                while x - ship_size < 1 do x <- x + 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x-i)) y
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    printfn "Checking Coord %s - Value = %b" coord board[coord]
                    if i = ship_size then checking <- false
                    i <- i + 1

    for i = 0 to ship_size - 1 do
        let coord = 
            if orientation = 1 then sprintf "%s%d" (convertToLetter(x)) (y-i)
            elif orientation = 2 then sprintf "%s%d" (convertToLetter(x+i)) (y)
            elif orientation = 3 then sprintf "%s%d" (convertToLetter(x)) (y+i)
            elif orientation = 4 then sprintf "%s%d" (convertToLetter(x-i)) (y)
            else invalidArg "InvalidOrientation" (sprintf "You cannot have an orientation of %d" orientation)

        board.[coord] <- true
        printfn "%s is now occupied by a ship" coord
                
printfn "************ Deploying P1 Battleship ************"
placeShip(5,1) //Player 1 Battleship
printfn "************ Deploying P1 Destroyer ************"
placeShip(4,1) //Player 1 Destroyer
printfn "************ Deploying P1 Destroyer ************"
placeShip(4,1) //Player 1 Destroyer

printfn "************ Deploying P2 Battleship ************"
placeShip(5,2) //Player 2 Battleship
printfn "************ Deploying P2 Destroyer ************"
placeShip(4,2) //Player 2 Destroyer
printfn "************ Deploying P2 Destroyer ************"
placeShip(4,2) //Player 2 Destroyer




