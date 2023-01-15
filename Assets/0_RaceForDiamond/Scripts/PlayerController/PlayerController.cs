using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RaceForDiamond
{
    public class PlayerController : MovementController
    {
        public Action OnBoosterCollected;
        [SerializeField] float boosterTimer = 3;
        private bool isBoosterOn;
        [SerializeField] private GameObject boosterEffect;
        float boosterLerpTime = 1;

        new void Start()
        {
            OnBoosterCollected += ActivateBooster;
            GetPlayerControllers();
            base.Start();
        }

        void FixedUpdate()
        {
            Movement();
            if (isBoosterOn)
            {
                tpc.MoveSpeedMultiplier = Mathf.Lerp(tpc.MoveSpeedMultiplier, 2.5f, boosterLerpTime * 2 * Time.deltaTime);
                tpc.AnimSpeedMultiplier = Mathf.Lerp(tpc.AnimSpeedMultiplier, 2.5f, boosterLerpTime * 2 * Time.deltaTime);
            }else
            {
                tpc.MoveSpeedMultiplier = Mathf.Lerp(tpc.MoveSpeedMultiplier, 1.5f, boosterLerpTime * Time.deltaTime);
                tpc.AnimSpeedMultiplier = Mathf.Lerp(tpc.AnimSpeedMultiplier, 1.5f, boosterLerpTime * Time.deltaTime);
            }
        }

        public override void RunAiAnimation(){}
        public override void ActivateBooster()
        {
           boosterEffect.SetActive(true);
            StartCoroutine(DeActivateBooster(boosterTimer));
            isBoosterOn = true;
        }
        IEnumerator DeActivateBooster(float _delay)
        {
            yield return new WaitForSeconds(_delay);
            boosterEffect.SetActive(false);
            isBoosterOn = false;
        }
    

        private void OnDestroy() => OnBoosterCollected -= ActivateBooster;

        public override void OnRaceFinish(int _rank)
        {
            base.FinishAnim(_rank);
            this.isRaceStarted = false;
            tpsc.enabled = false;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.position.z);
            GameManager.Instance.mapCamFollow.UnFollowCamera();

            if (_rank == 1)
                UIHandler.OnShowResultUI?.Invoke("You Win");
            else
                UIHandler.OnShowResultUI?.Invoke("You Loose");
        }



    }
}