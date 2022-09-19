using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackButton: MonoBehaviour {

    [SerializeField]
    public string sceneManager;


    public void Update()
    {
        if (Input.GetKeyDown("8"))
        {
            SceneManager.LoadScene(sceneManager);
        }
    }
}