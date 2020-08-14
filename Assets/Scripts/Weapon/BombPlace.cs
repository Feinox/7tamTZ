using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlace : MonoBehaviour
{
    private bool isPlaceEmpty = true;

    public void SetBombPlaceState(bool state)
    {
        isPlaceEmpty = state;
    }

    public bool GetBombPlaceState()
    {
        return isPlaceEmpty;
    }
}
