using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine("TestWait");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TestWait()
    {
        yield return new WaitForSeconds(3);

        Debug.Log("TestWait Function");
    }
}
