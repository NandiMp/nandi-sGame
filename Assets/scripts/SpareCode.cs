using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpareCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        SceneManager.LoadScene("game");
    }

    public void timer()
    {
        SceneManager.LoadScene("timer");
    }

    public void won()
    {
        SceneManager.LoadScene("won");
    }

    public void lost()
    {
        SceneManager.LoadScene("lost");
    }

    public void Quit()
    {
        Application.Quit();
    }


}
