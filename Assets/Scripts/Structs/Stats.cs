using UnityEngine;
using System.Collections;

public struct Stats {
    public string ID;
    public float Damage;
    public float BaseRateOfFire;
    public float Accuracy;
    public float MovementSpeed;

    public Stats(string id, float dama, float baseROF, float accu, float moveSpeed) {
        ID=id;
        Damage=dama;
        BaseRateOfFire=baseROF;
        Accuracy=accu;
        MovementSpeed=moveSpeed;

    }
}
