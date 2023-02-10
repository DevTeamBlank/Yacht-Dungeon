using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice12 : Dice {
    protected override int Roll() {
        if (count == 0) canTrigger = true;
        // Random.InitState(GameManager.Seed + count * 13 + RoundManager.Inst.currentRound * 17);
        return Random.Range(0, 6);
    }

    protected override void Trigger() {
        if (face == 5) {
            face = 0;
        } else {
            face++;
        }
        GetComponent<SpriteRenderer>().sprite = sprites_[face];
    }
}
