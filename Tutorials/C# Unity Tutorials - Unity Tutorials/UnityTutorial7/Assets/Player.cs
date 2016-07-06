using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
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
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(axisX, axisY) * Time.deltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            Debug.Log("I hit an enemy");
    }
}
