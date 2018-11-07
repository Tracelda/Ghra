using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour {

    public GameObject Loading;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject ScoreBox;
    private int ScoreText;
    private string ScoreNumber;
    private float alpha;
    private bool alphaDown;
    private bool alphaUp;
    private float timer;
    private string GameLevel;



    // Use this for initialization
    void Start() {
        alpha = 1f;
        timer = 0;
        LivesSelector();
        LevelSelect();
        ScoreText = StaticGame.score;
        ScoreNumber = ScoreText.ToString();
        Debug.Log(ScoreNumber);
        ScoreBox.gameObject.GetComponent<Text>().text = ScoreNumber;
    }

        
    

    // Update is called once per frame
    void Update() {
        
        

        Loading.gameObject.GetComponent<SpriteRenderer>().color = new Color(alpha, alpha, alpha, alpha);
        if (alpha >= 1)
        {
            alphaDown = true;
            alphaUp = false;
        }
        if (alpha <= 0)
        {
            alphaDown = false;
            alphaUp = true;
        }
        if (alphaDown == true)
            alpha = alpha - 0.03f;
        if (alphaUp == true)
            alpha = alpha + 0.03f;
        timer += Time.deltaTime;


        if (timer >= 2)
        {
            SceneManager.LoadScene(GameLevel);
        }
    }
    void LevelSelect()
    {
        switch (StaticGame.level)
        {
            case 1:
                {
                    GameLevel = "Level 1";
                    break;
                }
            case 2:
                {
                    GameLevel = "Level 2";
                    break;
                }
            case 3:
                {
                    GameLevel = "Level 3";
                    break;
                }
            case 4:
                {
                    GameLevel = "Level 4";
                    break;
                }
            case 5:
                {
                    GameLevel = "Level 5";
                    break;
                }
            case 6:
                {
                    GameLevel = "Level 6";
                    break;
                }
            case 7:
                {
                    GameLevel = "Level 7";
                    break;
                }
            case 8:
                {
                    GameLevel = "Level 8";
                    break;
                }

        }
    }
    void LivesSelector()
    {
        switch (StaticGame.Lives)
        {
            case 0:
                {
                    heart1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    heart2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    heart3.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    heart4.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    SceneManager.LoadScene("End");
                    break;
                }
            case 1:
                {
                    heart1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    heart2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    heart3.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    heart4.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                }
            case 2:
                {
                    heart1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    heart2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    heart3.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    heart4.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                }
            case 3:
                {

                    heart1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    heart2.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    heart3.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    heart4.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                }
            case 4:
                {
                    heart1.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    heart2.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    heart3.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    heart4.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                }

        }
    }
}
