using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private void ActiveDie()
    {
        ShipMove.die();
    }

    private void TurnOff()
    {
        this.gameObject.SetActive(false);
    }
}
