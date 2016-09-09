using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour
{
    public int progress = 0;
    private const int maxProgress = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float elapsed = Time.deltaTime;
        if (Input.GetButtonDown("DoorAction"))
        {
            progress++;

            if (progress >= maxProgress)
                Destroy(gameObject);

            Debug.Log(progress);
        }
    }
}
