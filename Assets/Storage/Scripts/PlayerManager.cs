using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public GameObject fire;

    void SpawFire()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(fire, this.transform.position, Quaternion.identity);
        }
    }

	void FixedUpdate ()
    {
        SpawFire();
    }
}
