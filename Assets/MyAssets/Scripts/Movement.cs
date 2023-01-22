using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    private void Start()
    {
        int currentScore = PlayerPrefs.GetInt("currentScore");

        if (currentScore <= 150)
        {
            speed = 5f;
        }
        else if (currentScore >= 150 && currentScore < 300)
        {
            speed = 5.5f;
        }
        else if (currentScore >= 300 && currentScore < 450)
        {
            speed = 6f;
        }
        else if (currentScore >= 450 && currentScore < 600)
        {
            speed = 6.5f;
        }
        else if (currentScore >= 600 && currentScore < 800)
        {
            speed = 7f;
        }
        else if (currentScore >= 800)
        {
            speed = 8f;
        }
    }

    public void SpeedZero()
    {
        speed = 0f;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime, 0f);
    }
}
