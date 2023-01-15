using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RaceForDiamond
{
    public class AIController : MovementController
    {
        [SerializeField] private NavMeshAgent navmeshAgent;
        new void Start()
        {
            base.Start();
            navmeshAgent.speed = runSpeed;
            myAnim.SetTrigger("isIdle");
        }

        void FixedUpdate()
        {
            AutoMove(navmeshAgent);
        }

        public override void RunAiAnimation()
        {
            myAnim.SetTrigger("isRunning");
            myAnim.ResetTrigger("isIdle");
        }
        public override void ActivateBooster(){}
        public override void OnRaceFinish(int _rank)
        {
            this.isRaceStarted = false;
            navmeshAgent.enabled = false;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.position.z);
            base.FinishAnim(_rank);
        }
    }

}