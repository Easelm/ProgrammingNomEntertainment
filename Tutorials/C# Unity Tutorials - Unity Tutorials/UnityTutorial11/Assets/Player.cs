using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private int score;
    private float speed;

    // Use this for initialization
    void Start()
    {
        score = 0;
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float axisY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, axisY) * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            score++;
            Debug.Log(score);
        }
    }
}
