module Blackjack.CardTypes

// Card definition types

type CardValue = { soft: int; hard: int }

type CardKind =
    | Ace
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King

let getCardKindValue =
    function
    | Ace -> { soft = 1; hard = 11 }
    | Two -> { soft = 2; hard = 2 }
    | Three -> { soft = 3; hard = 3 }
    | Four -> { soft = 4; hard = 4 }
    | Five -> { soft = 5; hard = 5 }
    | Six -> { soft = 6; hard = 6 }
    | Seven -> { soft = 7; hard = 7 }
    | Eight -> { soft = 8; hard = 8 }
    | Nine -> { soft = 9; hard = 9 }
    | Ten -> { soft = 10; hard = 10 }
    | Jack -> { soft = 10; hard = 10 }
    | Queen -> { soft = 10; hard = 10 }
    | King -> { soft = 10; hard = 10 }

let getCardKindShortName =
    function
    | Ace -> "A"
    | Two -> "2"
    | Three -> "3"
    | Four -> "4"
    | Five -> "5"
    | Six -> "6"
    | Seven -> "7"
    | Eight -> "8"
    | Nine -> "9"
    | Ten -> "T"
    | Jack -> "J"
    | Queen -> "Q"
    | King -> "K"

type CardSuit =
    | Diamond
    | Heart
    | Club
    | Spade

let getCardSuitShortName =
    function
    | Diamond -> "D"
    | Heart -> "H"
    | Club -> "C"
    | Spade -> "S"

type Card = { Kind: CardKind; Suit: CardSuit }

let getCardValue card = getCardKindValue card.Kind

let getCardShortName card =
    (getCardKindShortName card.Kind)
    + (getCardSuitShortName card.Suit)
