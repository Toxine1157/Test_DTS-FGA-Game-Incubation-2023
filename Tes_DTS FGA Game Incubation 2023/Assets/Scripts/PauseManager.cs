using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public KeyCode PauseKey;
    public KeyCode UnpauseKey;
    private Canvas cnv;

    public GameManager gameManager;

    public List<GameObject> TilesList;

    public void ReplayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(PauseKey))
        {
            Time.timeScale = 0;
            cnv.enabled = true;

            for (int i = 0; i < TilesList.Count; i += 1)
            {
                TilesList[i].GetComponent<BoxCollider2D>().enabled = false; // non aktifkan tiles collider
            }

            gameManager.TurnOffAllCollider();
        }

        if (Input.GetKeyDown(UnpauseKey))
        {
            Time.timeScale = 1;
            cnv.enabled = false;

            for (int i = 0; i < TilesList.Count; i += 1)
            {
                TilesList[i].GetComponent<BoxCollider2D>().enabled = true; // aktifkan tiles collider
            }

            gameManager.TurnOnPlacedBlockCollider();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        cnv = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
}
