using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public GameObject fire;

    public Transform actualPos;
    private Transform destiny;
    public float distance;
    public float angle;
    public float speed;
    private bool isFired;
    private bool isAreadyshoot;
    private Vector3 destinePos;
    private Vector2 destinyVect2;
    private Vector2 _direction;

    void Start()
    {
        speed = 25f;
    }

    void Fired()
    {
        isFired = true;

        if (isFired)
        { ShotTheFire(true); }

    }

    void ShotTheFire(bool follow)
    {
        if (follow)
        {
            Vector3 direction = destinePos;
            transform.position += direction * Time.deltaTime * speed;
        }
    }

    void SpawFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fire, this.transform.position, Quaternion.identity);
        }
        if (Input.GetMouseButton(0))
        {
            destinePos = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized.x, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized.y, this.transform.position.z);
            Fired();
        }
    }

	void FixedUpdate ()
    {
        SpawFire();
    }
}
