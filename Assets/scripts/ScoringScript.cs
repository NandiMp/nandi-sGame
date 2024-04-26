using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoringScript : MonoBehaviour
{
    public Transform goal;
    public TextMeshProUGUI scoreText;
    public float scoreNum = 0f;
    public float point = 1f;
    public string loseSceneName = "lost";
    public GameObject respawnPuck;
    public GameObject puck;

    public int consecutiveCollisions = 0;

    public void OnPuckCollision()
    {
        consecutiveCollisions++;
        if (consecutiveCollisions >= 2)
        {
            Debug.Log("moreThan2");
            scoreNum -= point;

            puck.transform.position = respawnPuck.transform.position;
            Rigidbody2D puckRb = puck.GetComponent<Rigidbody2D>();
            puckRb.velocity = Vector2.zero;
            puckRb.angularVelocity = 0f;

            if (scoreNum <= 0f)
            {
                scoreNum = 0f;
            }
            scoreText.text = scoreNum.ToString();
            consecutiveCollisions = 0;

            ResetPuck();

            if (scoreNum >= 5f)
            {
                SceneManager.LoadScene(loseSceneName);
            }
        }
    }

    void Start()
    {

    }

    private void Update()
    {
        if (puck.transform.position.y > 6f ||
            puck.transform.position.y < -6f ||
            puck.transform.position.x > 10f ||
            puck.transform.position.x < -10f)
        {
            ResetPuck();
        }

        if (scoreNum >= 5f)
        {
            SceneManager.LoadScene("lose");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            OnPuckCollision();
            if (collision.transform.position.x < goal.position.x)
            {
                scoreNum += point;
                scoreText.text = scoreNum.ToString();
                ResetPuck();
                consecutiveCollisions = 0;
                Debug.Log("shouldve worked");
            }
        }

        if (scoreNum >= 5f)
        {
            SceneManager.LoadScene(loseSceneName);
        }
    }

    void ResetPuck()
    {
        puck.transform.position = respawnPuck.transform.position;
        Rigidbody2D puckRb = puck.GetComponent<Rigidbody2D>();
        puckRb.velocity = Vector2.zero;
        puckRb.angularVelocity = 0f;
    }

}
