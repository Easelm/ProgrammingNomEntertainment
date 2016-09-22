using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        SaveSystem.Load();

        SceneManager.LoadScene(GameData.SceneIndex);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
