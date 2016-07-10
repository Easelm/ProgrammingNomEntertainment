using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int lives;
    private float speed;

    public GameObject projectilePrefab;
    public Text LivesText;

    // Use this for initialization
    void Start()
    {
        lives = 2;
        speed = 4.5f;
        LivesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 screenWorldPos = Camera.main.ScreenToWorldPoint(screenPos);

        if (Input.GetButtonDown("Shoot"))
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        if (screenPos.x <= 0)
            transform.position = new Vector3(screenWorldPos.x + 0.05f, screenWorldPos.y);
        else if (screenPos.x >= Screen.width)
            transform.position = new Vector3(screenWorldPos.x - 0.05f, screenWorldPos.y);
        else
            transform.Translate(new Vector3(axisX, 0) * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            LoseLife();
    }

    private void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            lives = 2;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
                Destroy(enemies[i]);
        }

        LivesText.text = "Lives: " + lives;
    }
}
