using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            AudioSource shoot = GetComponent<AudioSource>();
            shoot.Play();
        }
    }
}
