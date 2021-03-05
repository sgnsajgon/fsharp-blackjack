namespace Blackjack.Hand

open Blackjack
open CardTypes
open HandTypes

module EmptyHand =

    let deal: DealHand =
        fun emptyHand card1 card2 ->
            let cardValue1 = getCardValue card1
            let cardValue2 = getCardValue card2

            let (EmptyHand { Id = handId }) = emptyHand

            let initialHand =
                { Id = handId
                  Cards = [ card1; card2 ] }

            DealtHand.Initial(InitialHand initialHand)
