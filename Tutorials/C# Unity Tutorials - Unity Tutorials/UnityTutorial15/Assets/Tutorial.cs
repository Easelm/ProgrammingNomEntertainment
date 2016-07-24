using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    public GameObject parentGO;

    // Use this for initialization
    void Start()
    {
        Debug.Log(transform.GetChild(0).name);
        Debug.Log(parentGO.transform.GetChild(0).name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
