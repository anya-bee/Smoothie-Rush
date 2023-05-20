using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{

    public int level; 
    public float changetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(level);
    }

    private void Update()
    {

        changetime -= Time.deltaTime;
        if (changetime <= 0)
        {
            SceneManager.LoadScene(level);
        }

    }
}
