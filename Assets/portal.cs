using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene_name;
    void Start()
    {
        this.gameObject.tag = "portal";
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(){
        SceneManager.LoadScene(scene_name);
    }
}
