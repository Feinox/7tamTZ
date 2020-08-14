using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : PigWeapons
{
    public override void Shoot(Vector3 startPosition)
    {
        Instantiate(this, startPosition, Quaternion.identity);
    }

    public override WeaponType GetType()
    {
        return WeaponType.Bomb;
    }

}


