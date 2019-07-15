using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncherForward : MissileLauncher
{
        private ForwardMovement missile;

        public override void shoot()
        {
            base.shoot();
            missile = m.GetComponent<ForwardMovement>();
            missile.dir = shootPoint.transform.position - canonPart.transform.position;
        }
}
