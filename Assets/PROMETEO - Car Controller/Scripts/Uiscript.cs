using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Uiscript : MonoBehaviour
{
    public GameObject ourcar;
    Rigidbody carRigidbody;

    public AudioSource carEngineSound;
    float initialCarEngineSoundPitch;

    public Material materialGreen;
    public Material materialRed;
    public TMP_Text finalscore;
    public GameObject Startingscreen;
    public GameObject HomePage;
    public GameObject GameOverPage;
    public TMP_Text scoretext;
    [SerializeField]private int score = -1;

    int maximumtry = 0;
    public GameObject[] popup;
    public float popup_posx = 500.0f;
    public float popup_posy = 280.0f;
    public Button replay;
    private List<GameObject> popups = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (carEngineSound != null)
        {
            initialCarEngineSoundPitch = carEngineSound.pitch;
        }
        carRigidbody = ourcar.GetComponent<Rigidbody>();
        StartCoroutine(StartingScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (carEngineSound != null)
        {
            float engineSoundPitch = initialCarEngineSoundPitch + (Mathf.Abs(carRigidbody.velocity.magnitude) / 25f);
            carEngineSound.pitch = engineSoundPitch;
        }
    }
    IEnumerator StartingScene()
    {
        yield return new WaitForSeconds(1.5f);
        Startingscreen.SetActive(false);
        HomePage.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Set_Active(GameObject @object)
    {
        @object.SetActive(true);
    }
    public void Set_Inactive(GameObject @object)
    {
        @object.SetActive(false);
    }
    public void Set_pause()
    {
        Time.timeScale = 0.0f;
    }
    public void Set_play()
    {
        score = -1;
        scoretext.text = "Score: 0";
        Time.timeScale = 1.0f;
    }
    public void sound_active()
    {
        carEngineSound.Play();
    }
    public void Game_Over()
    {
        carEngineSound.Stop();
        GameOverPage.SetActive(true);
        if (score < 0) score = 0;
        finalscore.text = "Score: " + score.ToString();
        Time.timeScale = 0.0f;
    }

    public void Restart()
    {
        score = -1;
        scoretext.text = "Score: 0";
        if (maximumtry == 0)
        {
            carEngineSound.Play();
            GameOverPage.SetActive(false);
            Time.timeScale = 1.0f;
            maximumtry = Random.Range(1, 4);
        }
        else
        {
            replay.interactable = false;
            int maximumpopup = Random.Range(1, 6);
            while (maximumpopup != 0)
            {
                maximumpopup--;
                int index_pop = Random.Range(0, popup.Length);
                spawn_popup(popup[index_pop]);
            }
            maximumtry--;
        }
    }

    public void spawn_popup(GameObject specific_popup)
    {
        GameObject newpopup = Instantiate(specific_popup, GameOverPage.transform);
        RectTransform rectTransform = newpopup.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(Random.Range(-popup_posx, popup_posx), Random.Range(-popup_posy, popup_posy));
        newpopup.SetActive(true);
        popups.Add(newpopup);
    }


    public void Addscore(int val)
    {
        score += val;
        if (score < 0) scoretext.text = "Score: 0";
        else scoretext.text = "Score: " + score.ToString();
    }

    public void MaterialToGreen(GameObject car)
    {
        Renderer renderer = car.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = materialGreen;
        }
    }

    public void MaterialToRed(GameObject car)
    {
        Renderer renderer = car.GetComponent<Renderer>();
        if(renderer != null)
        {
            renderer.material = materialRed;
        }
    }

    public void destroy_popup(GameObject deletepopup)
    {
        popups.Remove(deletepopup);
        Destroy(deletepopup);

        if (popups.Count == 0)
        {
            replay.interactable = true;
        }
    }
}
