using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private enum GameText
    {
        TEXT_NONE,
        TEXT_MONEY,
        TEXT_MAX,
        TEXT_STATION,
        TEXT_DESK,
        TEXT_WALKER,
        TEXT_TIME
    }

    private enum GameButtons
    {
        BUTTON_DESK,
        BUTTON_WORKER,
        BUTTON_PLATFORM,
        BUTTON_MATERIALS,
        BUTTON_SEWING_MACHINE,
        BUTTON_EXTRA_WORKER
    }

    public GameObject BottomPanel;
    public GameObject OptionsPanel;
    public GameObject Stations;
    public GameObject ScrollViewContent;
    public GameObject[] Buttons;
    private GameObject deskPrefab;
    private GameObject materialPrefab;
    private GameObject workerPrefab;
    private GameObject SelectedStation = null;

    public Text DeskCostText;

    private int Money = 50;
    private int Desks = 0;
    private int Walkers = 0;
    private int DeskCost = 10;
    private int WorkerCost = 20;
    private int PlatformCost = 50;
    private int MaterialCost = 200;
    private int MachineCost = 600;
    private int ExtraWorkerCost = 1500;
    private int timeSeconds = 0;
    private int[,] MaterialCount = new int[10, 1];

    private const int DeskCostMultiplier = 1;
    private const int WorkerCostMultiplier = 2;
    private const int PlatformCostMultiplier = 5;
    private const int MaterialCostMultiplier = 10;
    private const int MachineCostMultiplier = 15;
    private const int ExtraWorkerCostMultiplier = 20;
    private const int BonusMultiplier = 6;

    private const int MaxMaterials = 5;

    private bool isBonusActive = false;

    private float Timer = 0;
    private float[] WorkTimers = new float[10];

    void Awake()
    {
        deskPrefab = (GameObject)Resources.Load("table");
        materialPrefab = (GameObject)Resources.Load("material");
        workerPrefab = (GameObject)Resources.Load("worker");
    }

    // Use this for initialization
    void Start()
    {
        SetMoney(Money);

        for (int i = 0; i < Stations.transform.childCount; i++)
        {
            int index = i;
            Button button = Stations.transform.GetChild(i).GetComponent<Button>();
            if (button != null)
                button.onClick.AddListener(delegate { OnStationClick(index); });
        }

        for (int i = 0; i < Buttons.Length; i++)
        {
            int index = i;
            Button button = Buttons[i].GetComponent<Button>();
            button.onClick.AddListener(delegate { OnUpgradeClick((GameButtons)index); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        float elapsed = Time.deltaTime;

        if (Input.GetButtonDown("Menu"))
        {
            OptionsPanel.SetActive(!OptionsPanel.activeSelf);
        }

        Timer += elapsed;
        if (Timer >= 1)
        {
            timeSeconds++;
            GetText(GameText.TEXT_TIME).text = string.Format("Time: {0}", timeSeconds);
            Timer = 0;
        }

        for (int i = 0; i < Stations.transform.childCount; i++)
        {
            if (Stations.transform.GetChild(i).GetComponent<Button>() != null)
            {
                if (Stations.transform.GetChild(i).childCount > 1)
                {
                    WorkTimers[i] += elapsed;
                    if (WorkTimers[i] >= 10)
                    {
                        if (MaterialCount[i, 0] < 6)
                        {
                            MaterialCount[i, 0] += 1;
                            if (MaterialCount[i, 0] == 1)
                            {
                                GameObject material = (GameObject)Instantiate(materialPrefab, Stations.transform.GetChild(i).position, Quaternion.identity);
                                material.transform.SetParent(Stations.transform.GetChild(i));
                                material.transform.position = new Vector3(material.transform.position.x - 50, material.transform.position.y + 25);
                            }
                        }
                        WorkTimers[i] = 0;
                    }
                }
            }
        }
    }

    private Text GetText(GameText text)
    {
        return BottomPanel.transform.GetChild((int)text).GetComponent<Text>();
    }

    private Text GetUpgradeText(int index)
    {
        return ScrollViewContent.transform.GetChild(index).GetChild(1).GetComponent<Text>();
    }

    private Button GetButton(GameButtons button)
    {
        return Buttons[(int)button].GetComponent<Button>();
    }

    private void SetMoney(int val)
    {
        Money = val;
        GetText(GameText.TEXT_MONEY).text = string.Format("Money: {0}", Money);
    }

    private void SetCost(int contentChildIndex, int cost, bool desk = false)
    {
        if (!desk)
            GetUpgradeText(contentChildIndex).text = string.Format("M: {0}", cost);
        else
            DeskCostText.text = string.Format("M: {0}", cost);
    }

    private bool HasDesk(int index)
    {
        GameObject go = Stations.transform.GetChild(index).gameObject;
        if (go.transform.childCount == 0)
            return false;

        return true;
    }

    private bool HasWorker(int index)
    {
        GameObject go = Stations.transform.GetChild(index).gameObject;
        if (go.transform.childCount == 1)
            return false;

        return true;
    }

    private void OnStationClick(int index)
    {
        GameObject station = Stations.transform.GetChild(index).gameObject;
        if (station)
        {
            SelectedStation = station;
            GetText(GameText.TEXT_STATION).text = string.Format("Station: {0}", index);
            if (!HasDesk(index))
                GetButton(GameButtons.BUTTON_DESK).interactable = true;
            else
            {
                GetButton(GameButtons.BUTTON_DESK).interactable = false;
                if (!HasWorker(index))
                    GetButton(GameButtons.BUTTON_WORKER).interactable = true;
                else
                    GetButton(GameButtons.BUTTON_WORKER).interactable = false;
            }

            if (MaterialCount[index, 0] > 0)
            {
                SetMoney(Money + MaterialCount[index, 0]);
                MaterialCount[index, 0] = 0;
                for (int i = 0; i < SelectedStation.transform.childCount; i++)
                {
                    if (SelectedStation.transform.GetChild(i).tag == "Material")
                        Destroy(SelectedStation.transform.GetChild(i).gameObject);
                }
            }
        }
    }

    private void OnUpgradeClick(GameButtons button)
    {
        if (SelectedStation == null)
            return;

        switch (button)
        {
            case GameButtons.BUTTON_DESK:
                if (Money >= DeskCost)
                {
                    GameObject desk = (GameObject)Instantiate(deskPrefab, SelectedStation.transform.position, Quaternion.identity);
                    desk.transform.SetParent(SelectedStation.transform);
                    desk.transform.position = new Vector3(desk.transform.position.x, desk.transform.position.y - 5);
                    GetButton(GameButtons.BUTTON_DESK).interactable = false;
                    SetMoney(Money - DeskCost);

                    DeskCost += DeskCostMultiplier;

                    SetCost(0, DeskCost, true);

                    GetButton(GameButtons.BUTTON_WORKER).interactable = true;
                }
                break;
            case GameButtons.BUTTON_WORKER:
                if (Money >= WorkerCost)
                {
                    GameObject worker = (GameObject)Instantiate(workerPrefab, SelectedStation.transform.position, Quaternion.identity);
                    worker.transform.SetParent(SelectedStation.transform);
                    worker.transform.position = new Vector3(worker.transform.position.x, worker.transform.position.y + 25);
                    GetButton(GameButtons.BUTTON_WORKER).interactable = false;
                    SetMoney(Money - WorkerCost);

                    WorkerCost += WorkerCostMultiplier;

                    SetCost(0, WorkerCost);
                }
                break;
        }
    }
}
