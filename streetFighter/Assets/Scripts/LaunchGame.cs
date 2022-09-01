/* Project name : streetFighterUnity 
 * Date : 13.09.2021
 * Authors : Jordan, R�my
 * Description : Lance le jeu si les deux joueurs ont choisi leurs personnages
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : StateMachineBehaviour
{
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Si un joueur annule sa s�lection le compte � rebours s'arr�te
		if (animator.GetBool("Interrupt"))
		{
			animator.Play("Normal");
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Si le compte � rebours arrive � z�ro La partie commence
		if (!animator.GetBool("Interrupt"))
		{
			if (SceneManager.GetActiveScene().name == "map Selection")
			{
				SceneManager.LoadScene("Battle");
				
			}else{
				SceneManager.LoadScene("map Selection");

			}
		}
	}
}