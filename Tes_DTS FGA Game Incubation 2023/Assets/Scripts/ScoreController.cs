using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public ScoreManager scoreManager;

    public TextMeshProUGUI ScoreTotal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTotal.text = scoreManager.score.ToString();
    }
}
