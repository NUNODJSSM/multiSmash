/* Project name : streetFighterUnity 
 * Date : 13.09.2021
 * Authors : Antoine
 * Description : Coup de pied de Ken
 */

using UnityEngine;

public class KenKick : MonoBehaviour
{
	public byte kbx;
	public byte kby;
	public byte damageKick = 20;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("tkt");
		if (collision.gameObject.tag == "Player")
		{
			MakeDamage.Hit(collision, damageKick, new Vector2(kbx, kby), gameObject);
		}
	}
}