using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveButton : MonoBehaviour
{
    public Button saveBtn;

    // Use this for initialization
    void Start()
    {
        saveBtn.onClick.AddListener(() =>
        {
            GameData.SceneIndex = SceneManager.GetActiveScene().buildIndex;
            SaveSystem.Save();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
