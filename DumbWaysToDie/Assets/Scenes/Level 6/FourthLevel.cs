using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FourthLevel : MonoBehaviour
{

    public GameObject bar;
    public Sprite face;
    public GameObject Platform;

    private float Timer;
    private float time;
    public float Tilt;

    // Use this for initialization
    void Start()
    {
        time = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        Platform.transform.Rotate(Input.acceleration.y * 0, 0, Input.acceleration.x * Tilt, Space.World);
        Timer = Time.deltaTime / StaticGame.seconds;
        time -= Timer;
        bar.gameObject.GetComponent<Slider>().value = time;
        if (time <= 0)
        {
            win();
        }

    }
    void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.gameObject.tag.Equals("face"))
        {
            lose();
        }
    }
    void win()
    {
        StaticGame.score += 10;
        end();
    }
    void lose()
    {
        StaticGame.Lives -= 1;
        end();
    }
    void end()
    {
        StaticGame.level += 1;       
        SceneManager.LoadScene("Loading");
    }

}
