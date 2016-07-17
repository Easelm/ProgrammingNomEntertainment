using UnityEngine;
using UnityEngine.UI;

public class SimpleUI : MonoBehaviour
{
    public Button button;

    // Use this for initialization
    void Start()
    {
        button.onClick.AddListener(ButtonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ButtonClick()
    {
        Debug.Log("Test button click");
    }
}
