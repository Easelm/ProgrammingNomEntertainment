using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject goScore;
    public GameObject goGameOver;

    private Rigidbody2D birdRigidbody;

    private Vector2 originalPos = Vector2.zero;

    public static bool GameStarted = false;

    public static int Score = 0;
    public static int BestScore = 0;

    private bool hasCollided = false;

    // Use this for initialization
    void Start()
    {
        originalPos = gameObject.transform.position;
        birdRigidbody = gameObject.GetComponent<Rigidbody2D>();

        goGameOver.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
        {
            goGameOver.SetActive(false);
            goScore.SetActive(true);
            hasCollided = false;

            goScore.GetComponent<Text>().text = "0";
            gameObject.transform.position = originalPos;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !hasCollided)
        {
            if (birdRigidbody.gravityScale == 0)
            {
                birdRigidbody.gravityScale = 0.6f;
                GameStarted = true;
            }

            birdRigidbody.AddForce(new Vector2(0, 15));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!hasCollided)
        {
            if (BestScore < Score)
                BestScore = Score;

            goGameOver.transform.GetChild(0).GetComponent<Text>().text = Score.ToString();
            goGameOver.transform.GetChild(1).GetComponent<Text>().text = BestScore.ToString();
            goGameOver.SetActive(true);
            goScore.SetActive(false);
            birdRigidbody.gravityScale = 0;
            Score = 0;
            GameStarted = false;
            hasCollided = true;
            return;
        }
    }

    public static bool GiveScore()
    {
        if (GameStarted)
        {
            Score++;
            return true;
        }

        return false;
    }
}
