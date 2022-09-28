/* Project name : streetFighterUnity 
 * Date : 13.09.2021
 * Authors : Jordan, Remy
 * Description : G�re la s�lection des boutons
 */

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonsNavigation : MonoBehaviour
{
	/// <summary>
	/// Objet contr�lant les �v�nement de l'interface utilisateur
	/// </summary>
	EventSystem eventSystem;
	int selection = 0;
	float time = 0;

	void Start()
	{
		// Initialisation
		eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
	}

	void Update()
	{
		if (GetComponentsInChildren<Button>(false).Length > 0)
		{
			time += Time.deltaTime;			
			float depx = Input.GetAxisRaw("Horizontal");
			if (depx>0 && time > 0.2){
				selection++;
				time = 0;
			}		
			if (depx<0 && time > 0.2){
				selection--;
				time = 0;
			}
			if (selection >= GetComponentsInChildren<Button>(false).Length)
				selection = 0;
			if (selection < 0)
				selection = GetComponentsInChildren<Button>(false).Length-1;
			GetComponentsInChildren<Button>(false)[selection].Select();
			/*
			if (Input.GetKeyDown("8"))
			{
				GetComponentsInChildren<Button>(false)[selection].onClick.Invoke();
			}
			*/
			
		}
	}
}