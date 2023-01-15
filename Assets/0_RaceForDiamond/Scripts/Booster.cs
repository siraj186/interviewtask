using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RaceForDiamond
{
    public class Booster : MonoBehaviour
    {
        private void Start() => RandomPosition(80, -80);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerController>(out var player))
            {
                player.OnBoosterCollected?.Invoke();
                gameObject.SetActive(false);
            }
        }

        private void RandomPosition(float arg1, float arg2)
        {
            float ranPos = UnityEngine.Random.Range(arg1, arg2);
            transform.position = new Vector3(ranPos, transform.position.y, transform.position.z);
        }
    }

}