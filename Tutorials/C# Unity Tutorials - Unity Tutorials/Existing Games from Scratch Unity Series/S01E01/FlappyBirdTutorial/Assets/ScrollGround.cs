using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * 0.4f, 0);
    }
}
