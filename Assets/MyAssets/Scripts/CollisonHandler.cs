using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField] LoadScenesManagger gameOverManagger;
    [SerializeField] AudioManagger soundsToPlay;


    private void Start()
    {
        GetComponentInChildren<Animator>().SetBool("happy", false);
        GetComponentInChildren<Animator>().SetBool("dead", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.tag == "PlayerRock")
        {
            if (collision.gameObject.tag == "EnemyScizzor")
            {
                FindObjectOfType<Score>().AddScore();
                ComponentsOnCollision(collision);
                soundsToPlay.Play("Ok");
                Destroy(collision.gameObject, 0.1f);
                StartCoroutine(HappyFace());
            }
            else
            {
                PlayerPrefs.SetFloat("EnemySpeed", 5f);
                StartCoroutine(DeadFace());
                soundsToPlay.Play("Lose");
                gameOverManagger.GameOver();
            }
        }

        if (gameObject.tag == "PlayerPaper")
        {
            if (collision.gameObject.tag == "EnemyRock")
            {
                FindObjectOfType<Score>().AddScore();
                ComponentsOnCollision(collision);
                soundsToPlay.Play("Ok");
                Destroy(collision.gameObject, 0.1f);
                StartCoroutine(HappyFace());
            }
            else
            {
                PlayerPrefs.SetFloat("EnemySpeed", 5f);
                StartCoroutine(DeadFace());
                soundsToPlay.Play("Lose");
                gameOverManagger.GameOver();
            }
        }

        if (gameObject.tag == "PlayerScizzor")
        {
            if (collision.gameObject.tag == "EnemyPaper")
            {
                FindObjectOfType<Score>().AddScore();
                ComponentsOnCollision(collision);
                soundsToPlay.Play("Ok");
                Destroy(collision.gameObject, 0.1f);
                StartCoroutine(HappyFace());
            }
            else
            {
                PlayerPrefs.SetFloat("EnemySpeed", 5f);
                StartCoroutine(DeadFace());
                soundsToPlay.Play("Lose");
                gameOverManagger.GameOver();
            }
        }
    }

    private static void ComponentsOnCollision(Collider2D collision)
    {
        collision.gameObject.GetComponentInChildren<Animator>().SetBool("dead", true);
        collision.gameObject.GetComponent<Movement>().SpeedZero();
    }

    IEnumerator HappyFace()
    {
        GetComponentInChildren<Animator>().SetBool("happy", true);
        yield return new WaitForSeconds(0.3f);
        GetComponentInChildren<Animator>().SetBool("happy", false);
    }

    IEnumerator DeadFace()
    {
        GetComponentInChildren<Animator>().SetBool("dead", true);
        yield return new WaitForSeconds(0.3f);
    }
}
