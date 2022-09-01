using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChanges : MonoBehaviour
{
    [SerializeField]
    List<GameObject> maps = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
            if (MapSelect.chosenMapNames != null){
                foreach (GameObject truc in maps)
                {
                    if (truc.name == MapSelect.chosenMapNames)
                    {
                        truc.SetActive(true);
                    }
                }
            }else{
                maps[0].SetActive(true);
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
