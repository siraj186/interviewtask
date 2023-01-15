using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

namespace RaceForDiamond
{
    public abstract class MovementController : MonoBehaviour
    {
        private FloatingJoystick floatingJoystick;
        [HideInInspector] public ThirdPersonUserControl tpsc;
        [HideInInspector] public ThirdPersonCharacter tpc;
        [HideInInspector] public GameObject diamond;
        public Animator myAnim;

        public float runSpeed = 50f;
        public bool isRaceStarted;
        public int rank;
        public void Start()
        {
            myAnim = GetComponent<Animator>();
            UIHandler.OnRaceStart += StartTheRace;
            diamond = GameManager.Instance.diamond;
        }

        public void GetPlayerControllers()
        {
            tpsc = GetComponent<ThirdPersonUserControl>();
            tpc = GetComponent<ThirdPersonCharacter>();
            floatingJoystick = GameManager.Instance.floatingjoystick;
        }

        public void Movement()
        {
            if (!isRaceStarted)
                return;

            tpsc.h = floatingJoystick.input.x;
            tpsc.v = floatingJoystick.input.y;
        }

        public void AutoMove(NavMeshAgent navmeshAgent)
        {
            if (!isRaceStarted)
                return;
            navmeshAgent.SetDestination(diamond.transform.position);
        }
        

        void StartTheRace(bool _isRaceStarted)
        {
            this.isRaceStarted = _isRaceStarted;
            RunAiAnimation();
        }

        public abstract void RunAiAnimation();
        public abstract void ActivateBooster();
        public abstract void OnRaceFinish(int _rank);


        public void FinishAnim(int _rank)
        {
            myAnim.Rebind();
            if (_rank == 1)
            {
                myAnim.SetTrigger("Victory");
            }else
            if(_rank == 2)
            {
                myAnim.SetTrigger("Lose");
            }
        }

        private void OnDestroy() => UIHandler.OnRaceStart -= StartTheRace;
       
    }
}