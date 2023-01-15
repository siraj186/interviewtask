using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaceForDiamond
{
	public class FollowPlayerCam : MonoBehaviour
	{
		private bool followPlayer = false;
		private Transform player;
		void Awake() => StartCoroutine(SetPlayer(0.5f));
        IEnumerator SetPlayer(float _delay)
		{
			yield return new WaitForSeconds(_delay);
			if (player == null)
				player = GameManager.Instance.myPlayer.transform;
			followPlayer = true;
		}

		void LateUpdate()
		{
			if (followPlayer)
			{
				Vector3 newPosition = player.position;
				newPosition.y = transform.position.y;
				transform.SetPositionAndRotation(newPosition, Quaternion.Euler(90f, player.eulerAngles.y, 0f));
            }
        }
		public void UnFollowCamera() { followPlayer = false; }
    }
}
