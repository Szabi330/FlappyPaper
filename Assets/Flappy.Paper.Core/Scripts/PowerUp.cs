using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Plane>() != null)
        {
            GameControl.instance.BirdPowerUpLife();
            this.transform.position = new Vector3(this.transform.position.x, 99999999, this.transform.position.z);
        }
    }
}
