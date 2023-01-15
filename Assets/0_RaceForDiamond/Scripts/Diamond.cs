using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RaceForDiamond
{
    public class Diamond : MonoBehaviour
    {
        public Transform testObj;
        public float aaa;
        bool isPlayerWin;
        int _rank;

       
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<MovementController>(out var racer))
            {
                _rank += 1;
                if (racer.CompareTag("Player") && !isPlayerWin)
                {
                    racer.rank = _rank;
                    if (_rank == 1)
                        isPlayerWin = true;
                    racer.OnRaceFinish(racer.rank);
                }
                if (racer.CompareTag("Opponent"))
                {
                    racer.rank = _rank;
                    racer.OnRaceFinish(racer.rank);
                }
                if (_rank >= 2)
                    GameManager.Instance.uihandler.EnableRestartButton();
            }
        }

        //editor only
        private void OnDrawGizmosSelected() // draw angle arc to check radius , To instantiate
        {
#if UNITY_EDITOR
            float _angle = 70; // -25
            Color c = new Color(.8f, 0, 0, 0.4f);
            UnityEditor.Handles.color = c;
            Vector3 rotatedForward = Quaternion.Euler(0, -_angle * 0.5f, 0) * transform.forward;
            UnityEditor.Handles.DrawSolidArc(transform.position, Vector3.up, rotatedForward, _angle, 400);  //400 is radiusRange from GameManager
#endif
        }
    }
}
