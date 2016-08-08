using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private enum Buttons
    {
        BUTTON_NEW_GAME,
        BUTTON_LOAD_GAME,
        BUTTON_OPTIONS,
        BUTTON_OKAY,
        BUTTON_SAVE,
        BUTTON_QUIT
    }

    public Button[] MenuButtons;
    public GameObject ButtonGO;
    public GameObject OptionsPanel;

    // Use this for initialization
    void Start()
    {
        GetButton(Buttons.BUTTON_NEW_GAME).onClick.AddListener(() => { SceneManager.LoadScene(1); });

        GetButton(Buttons.BUTTON_OPTIONS).onClick.AddListener(() =>
        {
            ToggleActivity(ButtonGO, false);
            ToggleActivity(OptionsPanel, true);
        });

        GetButton(Buttons.BUTTON_OKAY).onClick.AddListener(() =>
        {
            ToggleActivity(ButtonGO, true);
            ToggleActivity(OptionsPanel, false);
        });

        GetButton(Buttons.BUTTON_QUIT).onClick.AddListener(() => { Application.Quit(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Button GetButton(Buttons button)
    {
        return MenuButtons[(int)button];
    }

    private void ToggleActivity(GameObject go, bool active)
    {
        go.SetActive(active);
    }
}
