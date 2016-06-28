using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject goTopSpawner;
    public GameObject goBottomSpawner;
    public GameObject prefabTop;
    public GameObject prefabBottom;
    public Player player;

    private List<GameObject> Tunnels = new List<GameObject>();

    private float spawnTimer;

    // Use this for initialization
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsed = Time.deltaTime;
        if (Player.GameStarted)
        {
            spawnTimer += elapsed;
            if (spawnTimer >= Random.Range(3, 6))
            {
                GameObject tunnelTop = (GameObject)Instantiate(prefabTop, new Vector3(goTopSpawner.transform.position.x, goTopSpawner.transform.position.y + Random.Range(0.5f, 0.8f), 0),
                    Quaternion.identity);
                tunnelTop.transform.GetChild(0).GetComponent<ScoreTrigger>().player = player;
                tunnelTop.transform.Rotate(new Vector3(0, 0, 180));
                Tunnels.Add(tunnelTop);

                GameObject tunnelBottom = (GameObject)Instantiate(prefabBottom, new Vector3(goBottomSpawner.transform.position.x, goBottomSpawner.transform.position.y + Random.Range(0.5f, 0.8f), 0),
                    Quaternion.identity);
                Tunnels.Add(tunnelBottom);
                spawnTimer = 0;
            }

            for (int i = 0; i < Tunnels.Count; i++)
            {
                GameObject go = Tunnels[i];
                if (go.tag == "TunnelTop")
                    go.transform.Translate(new Vector3(2, 0, 0) * elapsed * 1);
                else
                    go.transform.Translate(new Vector3(-2, 0, 0) * elapsed * 1);

                if (go.transform.position.x <= -4)
                {
                    Tunnels.Remove(go);
                    DestroyObject(go);
                }
            }
        }
        else
        {
            spawnTimer = 0;
            if (Tunnels.Count > 0)
            {
                for (int i = 0; i < Tunnels.Count; i++)
                {
                    GameObject go = Tunnels[i];
                    DestroyObject(go);
                    Tunnels.Remove(go);
                }
            }
        }
    }
}
