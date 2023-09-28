// For more information see https://aka.ms/fsharp-console-apps
open System
open System.Collections.Generic
open System.Text.RegularExpressions

printfn "Game has Started.\nCommander, we have engaged the enemy fleet! It's Time for Battle!"
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

let placeShip (ship_size: int, player: int) =
    if ship_size > 5 then invalidArg "ship_size" (sprintf "Ship is too big for the game, do not exceed a size of 5")
    if player > 2 || player < 1 then invalidArg "player" (sprintf "There is only Player 1 and 2")
    let mutable valid = false
    let mutable x= System.Random().Next(1,11)
    let mutable y= 
        if player = 1 then System.Random().Next(1,6)
        else System.Random().Next(6,11)
    let mutable orientation = 0

    while valid = false do 
        x <- System.Random().Next(1,11)
        y <-
            if player = 1 then System.Random().Next(1,6)
            else System.Random().Next(6,11)
        orientation <- System.Random().Next(1, 5) //1 - North, 2 - East, 3 - South, 4 - West

        if player = 1 then
            if orientation = 1 && y - ship_size < 1 then
                while y - ship_size < 1 do y <- y + 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x)) (y-i)
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    if i = ship_size - 1 then checking <- false
                    i <- i + 1

            if orientation = 2 && 10 - x < ship_size then
                while 10 - x < ship_size do x <- x - 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x+i)) y
                    if board[coord] = true then 
                        valid <- false 
                        checking <- false
                    else valid <- true
                    if i = ship_size - 1 then checking <- false
                    i <- i + 1
                    

            if orientation = 3 && 6 - y < ship_size then
                while 6 - y < ship_size do y <- y - 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x)) (y+i)
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    if i = ship_size - 1 then checking <- false
                    i <- i + 1
                    

            if orientation = 4 && x - ship_size < 1 then
                while x - ship_size < 1 do x <- x + 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x-i)) y
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    if i = ship_size - 1 then checking <- false
                    i <- i + 1

        else
            if orientation = 1 && y - ship_size < 5 then
                while y - ship_size < 5 do y <- y + 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x)) (y-i)
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    if i = ship_size - 1 then checking <- false
                    i <- i + 1

            if orientation = 2 && 10 - x < ship_size then
                while 10 - x < ship_size do x <- x - 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x+i)) y
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    if i = ship_size - 1 then checking <- false
                    i <- i + 1
                

            if orientation = 3 && 10 - y < ship_size then
                while 10-y < ship_size do y <- y - 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x)) (y+i)
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    if i = ship_size - 1 then checking <- false
                    i <- i + 1
                

            if orientation = 4 && x - ship_size < 1 then
                while x - ship_size < 1 do x <- x + 1
                let mutable i = 0
                let mutable checking = true
                while checking = true do
                    let coord = sprintf "%s%d" (convertToLetter(x-i)) y
                    if board[coord] = true then 
                        valid <- false
                        checking <- false
                    else valid <- true
                    if i = ship_size - 1 then checking <- false
                    i <- i + 1

    for i = 0 to ship_size - 1 do
        let coord = 
            if orientation = 1 then sprintf "%s%d" (convertToLetter(x)) (y-i)
            elif orientation = 2 then sprintf "%s%d" (convertToLetter(x+i)) (y)
            elif orientation = 3 then sprintf "%s%d" (convertToLetter(x)) (y+i)
            elif orientation = 4 then sprintf "%s%d" (convertToLetter(x-i)) (y)
            else invalidArg "InvalidOrientation" (sprintf "You cannot have an orientation of %d" orientation)

        board.[coord] <- true
        if player = 1 then printfn "%s is now occupied by one of our ships" coord
                
printfn "************ Deploying P1 Battleship ************"
placeShip(5,1) //Player 1 Battleship
printfn "************ Deploying P1 Destroyer ************"
placeShip(4,1) //Player 1 Destroyer
printfn "************ Deploying P1 Destroyer ************"
placeShip(4,1) //Player 1 Destroyer


placeShip(5,2) //Player 2 Battleship
placeShip(4,2) //Player 2 Destroyer
placeShip(4,2) //Player 2 Destroyer

let mutable game_active = true

printfn "Commander! We need you to tell us which coordinate we should fire our missle at! Tell me in the format LetterNumber e.g. G6. The first part goes from A-J, the second part goes from 1-10!"
printfn "The enemy has populated the 6-10 sectors. We've deployed our ships to the 1-5 sectors. So make sure all guesses end in numbers from 6 to 10, otherwise we'll hit our own ships!"
printfn "If you ever want to Abandon the mission, just type 'Quit'."

let check_input(input: string) =
    let regex = Regex(@"^[A-J](?:[1-9]|10)$", RegexOptions.Compiled)
    regex.IsMatch(input)

let p2_guess() = 
    let x = System.Random().Next(1,11)
    let y = System.Random().Next(1,6)
    sprintf "%s%d" (convertToLetter(x)) y

let check_p1_remaining() =
    Seq.exists (fun y ->
        Seq.exists(fun x ->
            let coord = sprintf "%s%d" (convertToLetter(x)) y
            board.[coord] = true
        ) [1..10]
    ) [1..5]

let check_p2_remaining() =
    Seq.exists (fun y ->
        Seq.exists(fun x ->
            let coord = sprintf "%s%d" (convertToLetter(x)) y
            board.[coord] = true
        ) [1..10]
    ) [6..10]

while game_active = true do
    printf "Enter Coordinate: "
    let guess = Console.ReadLine()
    if guess = "Quit" || guess = "quit" then game_active <- false
    else
        if check_input(guess) then
            if board.[guess] = true then
                printfn "Hit Confirmed! We hit something!"
                board.[guess] <- false
            else printfn "Confirmed Miss!"
        else printfn "Commander... That's not a real coordinate..."
        let enemy_guess = p2_guess()
        if check_input(enemy_guess) then
            if board.[enemy_guess] = true then
                printfn "Commander! We've been hit by the Enemy at Point %s!" enemy_guess
                board.[enemy_guess] <- false
            else printfn "The Enemy have attempted to fire at Point %s! They've Missed!" enemy_guess
        else printfn "They can't fire there..."
        if check_p1_remaining() = false then 
            printfn "Commander... All our ships have been destroyed... We've been defeated..."
            game_active <- false
        if check_p2_remaining() = false then
            printfn "Commander! We have defeated all enemy ships, We have claimed our victory!"
            game_active <- false