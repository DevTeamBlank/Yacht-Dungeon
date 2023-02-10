using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Entity {

    public Sprite[] sprites_ = new Sprite[10];

    void Update() {
        SelectEntity();

        if (onAnimation) {
            time += Time.deltaTime;
            if (animationDelay_ <= time) {
                if (count < sprites_.Length - 1) {
                    time = 0;
                    count++;
                    GetComponent<SpriteRenderer>().sprite = sprites_[count];
                } else {
                    onAnimation = false;
                    time = 0;
                    count = 0;
                    // TODO
                    // RoundManager ȣ��
                }
            }
        }
    }

    public override void SetMaxHp() {
        maxHp = EnemyManager.Inst.MeteorHp();
        hp = maxHp;
        HPUpdate();
    }

    RaycastHit2D hit;
    GameObject target;

    protected override void SelectEntity() {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);

            if (hit.collider != null) {
                target = hit.collider.gameObject;
                if (target == gameObject) {
                    AttackManager.Inst.SelectEntity(true);
                }
            }
        }
    }

    public void ResetAnimation() {
        GetComponent<SpriteRenderer>().sprite = sprites_[0];
    }

}
