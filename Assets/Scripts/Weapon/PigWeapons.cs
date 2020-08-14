using UnityEngine;


public abstract class PigWeapons: MonoBehaviour
{
   public abstract WeaponType GetType();
   public abstract void Shoot( Vector3 startPosition);
}


public enum WeaponType
{
    Bomb
}