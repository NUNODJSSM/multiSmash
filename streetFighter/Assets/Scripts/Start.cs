using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/*
 * Aymeric Siegenthaler
 * Classe P3B
 * 29.08.2022
 * Version 1
 */
public class Start : MonoBehaviour, ISelectHandler
{
    Button selectedBtn;
    /// <summary>
    /// Fonction appellée de manière repétée servant à vérifier si l'utilisateur a appuyé sur la touche 8($ sur l'arcade)
    /// </summary>
    void Update()
    {
        // Si le 8 est pressé(le $ sur l'arcade)
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            // On invoque un click
            selectedBtn.onClick.Invoke();
        }
    }
    /// <summary>
    /// Fonction appellée quand le button est sélectionné. Elle met dans une variable le button sélectioné.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnSelect(BaseEventData eventData)
    {
        // On met dans une variable le button qui à été cliqué
        selectedBtn = GameObject.Find(eventData.selectedObject.name).GetComponent<Button>();
    }
}