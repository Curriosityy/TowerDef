using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GunTurret : Turret
{
    
    protected override void Fire()
    {
        var projectile = Instantiate(ProjectilePrefav);
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;
        projectile.GetComponent<ProjectileBehaviour>().Initialize(Target);
    }
}

