module Blackjack.HandTypes

open Blackjack.CardTypes

// Hand definition types

type HandId = HandId of string

type Hand = { Id: HandId; Cards: Card list }

// All possible hand states

type EmptyHand = EmptyHand of Hand
type InitialHand = InitialHand of Hand
type SplitableHand = SplitableHand of Hand
type AcesSplittableHand = AcesSplittableHand of Hand
type BlackjackHand = Blackjack of Hand
type OneCardHand = OneCardHand of Hand
type InPlayHand = InPlayHand of Hand
type StoodHand = StoodHand of Hand
type BustedHand = BustedHand of Hand

// Deal action possible transitions

type DealtHand =
    | Initial of InitialHand
    | Splitable of SplitableHand
    | AcesSplittable of AcesSplittableHand
    | Blackjack of BlackjackHand

type DealHand = EmptyHand -> Card -> Card -> DealtHand

// Hit action possible transitions

type HittableHand =
    | Dealt of InitialHand
    | Splitable of SplitableHand
    | AcesSplittable of AcesSplittableHand
    | InPlay of InPlayHand

type HitHand =
    | InPlay of InPlayHand
    | Stood of StoodHand
    | Busted of BustedHand

type Hit = HittableHand -> Card -> HitHand

// Double action possible transitions

type DoubleableHand =
    | Dealt of InitialHand
    | Splitable of SplitableHand
    | AcesSplittable of AcesSplittableHand

type DoubledHand =
    | StoodHand
    | BustedHand

type Double = DoubleableHand -> Card -> DoubledHand

// Split action possible transitions

type SplitFirstHand =
    | InPlay of InPlayHand
    | Stood of StoodHand

type SplitSecondHand =
    | OneCard of OneCardHand
    | InPlay of InPlayHand
    | Stood of StoodHand

type SplitHand =
    { First: SplitFirstHand
      Second: SplitSecondHand }

type AcesSplitHand = { First: StoodHand; Second: StoodHand }

type Split = SplitableHand -> Card -> SplitHand
type AcesSplit = AcesSplittableHand -> Card -> Card -> AcesSplitHand

// Stand action possible transitions

type StandableHand =
    | Initial of InitialHand
    | Splitable of SplitableHand
    | AcesSplittable of AcesSplittableHand
    | InPlay of InPlayHand

type Stand = StandableHand -> StoodHand
