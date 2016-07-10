using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private float speed;

    // Use this for initialization
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y >= Screen.height)
            Destroy(gameObject);

        transform.Translate(new Vector3(0, 1) * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}
