using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button playBtn;
    public Button exitBtn;

    // Use this for initialization
    void Start()
    {
        playBtn.onClick.AddListener(() => { SceneManager.LoadScene("game"); });
        exitBtn.onClick.AddListener(() => { Application.Quit(); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
