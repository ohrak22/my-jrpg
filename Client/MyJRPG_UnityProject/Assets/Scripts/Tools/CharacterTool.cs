using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTool : MonoBehaviour {

	public CharAniControl charAni;

	public void OnIdle()
	{
		charAni.PlayAni(CharAniControl.State.BattleIdle);
	}

	public void OnAttack()
	{
		charAni.PlayAni(CharAniControl.State.Attack);
	}

	public void OnHit()
	{
		charAni.PlayAni(CharAniControl.State.Hit);
	}

}
