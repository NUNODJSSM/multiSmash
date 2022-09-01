/* Project name : streetFighterUnity 
 * Date : 13.09.2021
 * Authors : Jordan, Rémy
 * Description : Sélection des personnages
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{
    /// <summary>
	/// GameObjects de sélection des maps
	/// </summary>
	GameObject[] maps;

	/// <summary>
	/// Images des personnages jouables
	/// </summary>
	[SerializeField]
	List<Sprite> images = new List<Sprite>();

	/// <summary>
	/// Compte à rebours du lancement de la partie
	/// </summary>
	Animator countdown;

	/// <summary>
	/// Si les joueurs ont appuyé sur un bouton de validation
	/// </summary>
	bool pressedValidation =false;

	/// <summary>
	/// Si les joueurs ont appuyé sur le bouton de gauche
	/// </summary>
	bool pressedLeft = false;

	/// <summary>
	/// Si les joueurs ont appuyé sur le bouton de droite
	/// </summary>
	bool pressedRight = false;

    /// <summary>
	/// Couleur par défaut des bordures des personnages
	/// </summary>
	Color32 defaultColor;

    /// <summary>
	/// Noms de la map sélectionnés
	/// </summary>
	public static string chosenMapNames;

    /// <summary>
	/// Index de la map dans la liste
	/// </summary>
    int mapIndex = 0;

    /// <summary>
	/// Couleur des bordures des personnages sélectionnés
	/// </summary>
	Color32 VALIDATED_COLOR = new Color32(0, 255, 0, 255);

    /// <summary>
	/// Noms des axes de validation des joueurs
	/// </summary>
	List<string> validationAxisNames = new List<string>()
	{
		
			"Attack1Player1",
			"Attack2Player1",
		
		
			"Attack1Player2",
			"Attack2Player2"
		
	};

	void Start()
	{
		// Initialisation des variables
		maps = GameObject.FindGameObjectsWithTag("Selection");
		defaultColor = maps[0].GetComponent<Outline>().effectColor;
		countdown = GameObject.Find("Countdown").GetComponent<Animator>();
		chosenMapNames = "";

		// Importation des images
		foreach (Texture2D image in Resources.LoadAll<Texture2D>("maps"))
		{
			images.Add(Sprite.Create(image, new Rect(Vector2.zero, new Vector2(image.width, image.height)), new Vector2(0.5f, 0.5f)));
			images[images.Count - 1].name = image.name.Replace("Choice", string.Empty);
		}
		maps[0].transform.GetChild(0).GetComponent<Image>().sprite = images[mapIndex];
		
	}

	void Update()
	{
		// Boucle pour les deux joueurs
		
			MapChanges(0);

			Validation(0);
		

		Countdown();
	}

	/// <summary>
	/// Change le personnage du joueur
	/// </summary>
	/// <param name="iMap">Index du joueur</param>
	void MapChanges(int iMap)
	{
		if (maps[iMap].GetComponent<Outline>().effectColor != VALIDATED_COLOR)
		{
			if (Input.GetAxis("HorizontalPlayer" + (iMap + 1)) < 0)
			{
				if (!pressedLeft)
				{
					pressedLeft = true;

					if (mapIndex > 0)
					{
						mapIndex--;
					}
					else
					{
						mapIndex = images.Count - 1;
					}

					maps[0].transform.GetChild(1).GetComponent<Animator>().SetTrigger("Move");
					maps[0].transform.GetChild(0).GetComponent<Image>().sprite = images[mapIndex];
				}
			}
			else if (Input.GetAxis("HorizontalPlayer" + (iMap + 1)) > 0)
			{
				if (!pressedRight)
				{
					pressedRight = true;

					if (mapIndex < images.Count - 1)
					{
						mapIndex++;
					}
					else
					{
						mapIndex = 0;
					}

					maps[0].transform.GetChild(2).GetComponent<Animator>().SetTrigger("Move");
					maps[0].transform.GetChild(0).GetComponent<Image>().sprite = images[mapIndex];
				}
			}
			else
			{
				pressedLeft = false;
				pressedRight = false;
			}
		}
	}

	/// <summary>
	/// Valide le choix du joueur
	/// </summary>
	/// <param name="iMap">Index du joueur</param>
	void Validation(int iMap)
	{
		bool validationKeyDown = false;

		foreach (string axisName in validationAxisNames)
		{
			if (Input.GetAxis(axisName) > 0)
			{
				validationKeyDown = true;
			}
		}

		if (validationKeyDown)
		{
			if (!pressedValidation)
			{
				pressedValidation = true;

				if (maps[0].GetComponent<Outline>().effectColor == VALIDATED_COLOR)
				{
					maps[0].GetComponent<Outline>().effectColor = defaultColor;

					for (int iChild = 1; iChild < maps[0].transform.childCount; iChild++)
					{
						maps[0].transform.GetChild(iChild).gameObject.SetActive(true);
					}
				}
				else
				{
					maps[0].GetComponent<Outline>().effectColor = VALIDATED_COLOR;

					for (int iChild = 1; iChild < maps[0].transform.childCount; iChild++)
					{
						maps[0].transform.GetChild(iChild).gameObject.SetActive(false);
					}

					chosenMapNames = images[mapIndex].name;
				}
			}
		}
		else
		{
			pressedValidation = false;
		}
	}

	/// <summary>
	/// Lancement du compte à rebours
	/// </summary>
	void Countdown()
	{
		if (maps[0].GetComponent<Outline>().effectColor == VALIDATED_COLOR)
		{
			countdown.SetTrigger("Selected");
			countdown.ResetTrigger("Interrupt");
		}
		else
		{
			countdown.ResetTrigger("Selected");
			countdown.SetTrigger("Interrupt");
		}
	}
}