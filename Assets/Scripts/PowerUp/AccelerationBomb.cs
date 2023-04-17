using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationBomb : PowerUp
{
    void Update()
    {
        MyUpdate();
    }

    public override void AddEffect(PlayerBombGenerator playerUseBomb)
    {
        playerUseBomb.GetPowerUpBomb(timePowerUp);
    }
}
