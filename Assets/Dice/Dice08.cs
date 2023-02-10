using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice08 : Dice {
    protected override int Roll() {
        if (count == 0) {
            // Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
            return Random.Range(0, 6);
        } else {
            if (face == 5) {
                return 0;
            } else {
                return face + 1;
            }
        }
    }
}
