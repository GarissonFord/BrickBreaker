using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private int initialLives;
    private int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = initialLives;
    }

    public void LoseLife()
    {
        currentLives -= 1;
        if(currentLives <= 0)
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
