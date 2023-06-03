using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //GameObject timerBar;
    public float timeLeft;

    public bool startTime;

    public Canvas cnv;

    public GameManager gameManager;

    public List<GameObject> TilesList;
    // Start is called before the first frame update
    void Start()
    {
        //timerBar.GetComponent<Transform>();
        timeLeft = 10;
        startTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        //timerBar = transform.position;
        //timeLeft -= Time.deltaTime;

        if(timeLeft > 0 && startTime == true)
        {
            transform.localScale -= new Vector3(0.3f, 0, 0) * Time.deltaTime;
            timeLeft -= Time.deltaTime;
        }
        
        if(timeLeft <= 0)
        {
            timeLeft = 10;
            transform.localScale = new Vector3(3, 0.5f, 1);

            cnv.enabled = true;

            for (int i = 0; i < TilesList.Count; i += 1)
            {
                TilesList[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            gameManager.TurnOffAllCollider();

            startTime = false;
        }
    }
}
