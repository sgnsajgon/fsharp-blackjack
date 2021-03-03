module Blackjack.HandTypes

// Card definition types

type CardValue = { soft: byte; hard: byte }

type CardKind =
    | Ace of CardValue
    | Two of CardValue
    | Three of CardValue
    | Four of CardValue
    | Five of CardValue
    | Six of CardValue
    | Seven of CardValue
    | Eight of CardValue
    | Nine of CardValue
    | Ten of CardValue
    | Jack of CardValue
    | Queen of CardValue
    | King of CardValue
    
type CardSuit =
    | Diamond
    | Heart
    | Club
    | Spade

type Card = CardKind * CardSuit

// All possible hand states

type EmptyHand = unit
type DealtHand = unit
type SplitableHand = unit
type AcesSplittableHand = unit
type BlackjackHand = unit
type InPlayHand = unit
type StoodHand = unit
type BustedHand = unit
type HalfHand = unit

// Deal action possible transitions

type DealResult =
    | DealtHand of DealtHand
    | SplitableHand of SplitableHand
    | AcesSplittableHand of AcesSplittableHand
    | BlackjackHand of BlackjackHand

type deal = EmptyHand -> Card -> DealResult

// Hit action possible transitions

type HittableHand =
    | DealtHand of DealtHand
    | SplitableHand of SplitableHand
    | AcesSplittableHand of AcesSplittableHand
    | InPlayHand of InPlayHand
    
type HitResult =
    | InPlayHand of InPlayHand
    | StoodHand of StoodHand
    | BustedHand of BustedHand

type hit = HittableHand -> Card -> HitResult

// Double action possible transitions

type DoubleableHand =
    | DealtHand of DealtHand
    | SplitableHand of SplitableHand
    | AcesSplittableHand of AcesSplittableHand

type DoubleResult =
    | StoodHand
    | BustedHand
    
type double = DoubleableHand -> Card -> DoubleResult

// Split action possible transitions

type SplitFirstResult =
    | InPlayHand of InPlayHand
    | StoodHand of StoodHand

type SplitSecondResult =
    | HalfHand of HalfHand
    | InPlayHand of InPlayHand
    | StoodHand of StoodHand

type SplitResult = {
        FirstHand: SplitFirstResult
        SecondHand : SplitSecondResult
    }

type AcesSplitResult = {
    FirstHand: StoodHand
    SecondHand: StoodHand
}

type split = SplitableHand -> Card -> SplitResult
type acesSplit = AcesSplittableHand -> Card -> Card -> AcesSplitResult