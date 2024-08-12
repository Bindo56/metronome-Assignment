using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class linkOpener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Link()
    {
        Application.OpenURL("https://github.com/Bindo56");
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
