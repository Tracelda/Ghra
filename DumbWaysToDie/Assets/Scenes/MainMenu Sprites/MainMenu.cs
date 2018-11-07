using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StaticGame.Lives = 4;
        StaticGame.seconds = 6;
        StaticGame.level = 1;
        StaticGame.score = 0;
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << LayerMask.NameToLayer("UseableObject"));

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Hit.collider != null)
            {
                if (Hit.collider.gameObject.tag.Equals("Button"))
                {
                    Debug.Log("clicking start");
                    SceneManager.LoadScene("Level 1");
                }
            }
        }
    }
}
