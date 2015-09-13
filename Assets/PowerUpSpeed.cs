using UnityEngine;
using System.Collections;


public class PowerUpSpeed : PowerParent  {

    public override void Activate()
    {
        _player.GetComponent<Rigidbody>().velocity += new Vector3(0,0,60f);
        base.Activate();
    }

}
