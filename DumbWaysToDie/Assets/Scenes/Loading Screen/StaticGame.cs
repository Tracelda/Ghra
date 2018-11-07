using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticGame
{

    private static int _lives;
    private static int _level;
    private static float _seconds;
    private static int _score;

    public static int Lives
    {
       get 
        {
            return _lives;
        }
        set
        {
            _lives = value;
        }
                  
    }
    public static int level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
        
    }
    public static float seconds
    {
        get
        {
            return _seconds;
        }
        set
        {
            _seconds = value;
        }
    }
    public static int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }
}




	
	
	
