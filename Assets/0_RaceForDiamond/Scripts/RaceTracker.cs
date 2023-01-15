using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace RaceForDiamond
{
    public class RaceTracker : MonoBehaviour
    {
        public Slider playerSlider, aiSlider;
        private GameObject player, opponent, finishObj;
        private float finalDistance;
        float playerDistance;
        float opponentDistance;

        void Start() => StartCoroutine(InitializeAll(2));
        IEnumerator InitializeAll(float _delay)
        {
            yield return new WaitForSeconds(_delay);
            player = GameManager.Instance.myPlayer.transform.gameObject;
            opponent = GameManager.Instance.opponentPlayer;
            finishObj = GameObject.FindObjectOfType<Diamond>().gameObject;
            finalDistance = Vector3.Distance(player.transform.position, finishObj.transform.position);
            playerSlider.maxValue = finalDistance;
            aiSlider.maxValue = finalDistance;

            playerSlider.value = finalDistance;
            aiSlider.value = finalDistance;
        }
       
        private void FixedUpdate()
        {
            if (player == null)
                return;

            playerDistance = Vector3.Distance(player.transform.position, finishObj.transform.position);
            opponentDistance = Vector3.Distance(opponent.transform.position, finishObj.transform.position);

            playerSlider.value = playerDistance;
            aiSlider.value = opponentDistance;
        }
    }
}