using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public GameObject projectilePrefab;

    private List<GameObject> Projectiles = new List<GameObject>();

    private float projectileVelocity;

    // Use this for initialization
    void Start()
    {
        projectileVelocity = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectiles.Add(bullet);
        }

        for (int i = 0; i < Projectiles.Count; i++)
        {
            GameObject goBullet = Projectiles[i];
            if (goBullet != null)
            {
                goBullet.transform.Translate(new Vector3(0, 1) * Time.deltaTime * projectileVelocity);

                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);
                if (bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0)
                {
                    DestroyObject(goBullet);
                    Projectiles.Remove(goBullet);
                }
            }
        }
    }
}
