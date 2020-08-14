using UnityEngine;
using System.Collections.Generic;

public class PigController : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private float Speed = 2.0f;
    [SerializeField] private PigWeaponrScriptableObject _pigWeapons;

    private float angle = 0.1218693434f;
    private Rigidbody2D _Rigidbody;
    private Transform _PigyTransform;
    public Joystick joystick;
    List<Collider2D> stoneColliders = new List<Collider2D>();

    private WeaponType _currentWeaponType = WeaponType.Bomb;
    
    #endregion


    #region Unity lifecycle

    private void Start () 
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
        _PigyTransform = transform;// cashed transform (get componet every frame bad)
    }

    public void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        if (vertical > 0)
        {
            horizontal = Mathf.Sin(angle);
        }
        else if (vertical < 0)
        {
            horizontal = Mathf.Sin(-angle);
        }

        if (horizontal != 0 || vertical != 0)
        {
            Move (new Vector3(horizontal, vertical, 0f));
        }
        else
        {
            Idle();
        }
    }

    #endregion
    

    #region Private methods

    private void Move(Vector3 direction)
    {
        var endPosition = _PigyTransform.position + direction * (Speed * Time.deltaTime);
        _Rigidbody.MovePosition(endPosition);
    }
    
    private void Idle()
    {
        _Rigidbody.velocity = Vector2.zero;
    }

    public void BombSpawn()
    {
        foreach (var weapon in _pigWeapons.Weapons)
        {
            if (weapon.GetType() == _currentWeaponType)//can expanding the choice of weapons(need weapon controller)
            {
                if (stoneColliders.Count == 0) return;

                var a = stoneColliders[stoneColliders.Count - 1].GetComponent<BombPlace>();
                if (a.GetBombPlaceState())
                {
                    a.SetBombPlaceState(false);
                    weapon.Shoot(a.transform.position);
                } 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
        
    {
        stoneColliders.Add(other);   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        stoneColliders.Remove(other);
    }
    #endregion
}