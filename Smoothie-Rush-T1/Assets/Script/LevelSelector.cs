using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{

    public int level; 
    public float changetime;
    public bool changescene;
    public BoxCollider2D triggerChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        OpenScene();
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(level);
    }

    private void Update()
    {
        if (changescene)
        {
            changetime -= Time.deltaTime;
            if (changetime <= 0)
            {
                SceneManager.LoadScene(level);
            }
        }

    }
}
