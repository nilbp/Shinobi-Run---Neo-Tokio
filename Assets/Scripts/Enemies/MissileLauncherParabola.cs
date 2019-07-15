using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncherParabola : MissileLauncher
{
    private ParabolicShoot missile;

    public override void shoot()
    {
        base.shoot();
        missile = m.GetComponent<ParabolicShoot>();
        missile.startForce = shootPoint.transform.position - canonPart.transform.position ;
    }
}
