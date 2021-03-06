﻿namespace Blackjack

type HandId = HandId of uint

type BetAmount = BetAmount of uint

type SideBet =
    | PerfectPair of BetAmount
    | Twenty1plus3 of BetAmount

type Bet =
    | Main of BetAmount
    | SideBet of SideBet

type HandBet = { HandId: HandId; Bets: Bet list  }

type DealAction = HandBet list

type Action =
    | Deal of DealAction
    | Hit
    | Stand
    | Double
    | Split
    | Surrender
    | Insurance
    | InsuranceAll
    | EvenMoney
    | EvenMoneyAll
    
type GameEvent =
    | TableHandDealt
    | Blackjack
    | InsuranceOffered
    | InsuranceAllOffered
    | EvenMoneyOffered
    | EvenMoneyAllOffered
    | HandHit
    | HandStood
    | HandDoubled
    | HandSplit
    | HandBusted
    | HandWon
    | HandPushed
    | HandSurrendered
    | HandLost
    
type ProcessAction = Action -> GameEvent list