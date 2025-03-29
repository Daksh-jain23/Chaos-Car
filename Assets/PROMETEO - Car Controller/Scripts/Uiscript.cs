using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Uiscript : MonoBehaviour
{
    public GameObject Startingscreen;
    public GameObject HomePage;
    public GameObject GameOverPage;
    public TMP_Text scoretext;
    public int score = -1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartingScene());
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator StartingScene()
    {
        yield return new WaitForSeconds(3);
        Startingscreen.SetActive(false);
        HomePage.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Play()
    {
        HomePage.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Game_Over()
    {
        GameOverPage.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        GameOverPage.SetActive(false );
        Time.timeScale = 1.0f;
    }
    public void Addscore()
    {
        score++;
        scoretext.text = "Score: " + score.ToString();
    }
}
