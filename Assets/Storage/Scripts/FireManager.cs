using UnityEngine;
using System.Collections;

public class FireManager : MonoBehaviour
{
    public Transform actualPos;
    private Transform destiny;
    public float distance;
    public float angle;
    public float speed;
    private bool isFired;
    private bool isAreadyshoot;
    private Vector3 destinePos;
    private Vector2 destinyVect2;
    private int count;
    private Vector2 _direction;

    void Start()
    {
        speed = 50f;
    }

    void rotate()
    {
        destinyVect2 = new Vector2(destinePos.x, destinePos.y);
        _direction = (destinyVect2 - (Vector2)transform.position).normalized;
        angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg + (int)0;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
            Vector3 direction = new Vector3 ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized.x, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized.y, this.transform.position.z);
            transform.position += direction * Time.deltaTime * speed;

        }
    }

    void FixedUpdate()
    {
        Fired();
        rotate();
    }
}