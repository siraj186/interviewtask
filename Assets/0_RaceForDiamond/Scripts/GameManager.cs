using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RaceForDiamond
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject myPlayer;
        public GameObject opponentPrefab;
        public GameObject diamond;
        [HideInInspector] public GameObject opponentPlayer;

        public FloatingJoystick floatingjoystick;
        public UIHandler uihandler;
        public FollowPlayerCam mapCamFollow;
        [SerializeField] private readonly int radiusRange = 400;
        private float opponentInstantiateAngle; //will be random when initialization
        [SerializeField] float min, max;
        Vector3 newposition;
       
        void Start() => InstantiateOpponent(opponentPrefab);

        public void InstantiateOpponent(GameObject gob)
        {
            Transform player = myPlayer.transform;
            Vector3 dir = player.position - diamond.transform.position;
            float length = dir.magnitude;
            opponentInstantiateAngle = UnityEngine.Random.Range(min, max);
            newposition = new Vector3(Mathf.Cos(opponentInstantiateAngle), 0, Mathf.Sin(opponentInstantiateAngle)) * radiusRange;
            opponentPlayer = Instantiate(gob, newposition, Quaternion.identity);
        }

        //////////dummy, to take angles of Opponent;//////////
        //[SerializeField] private float aaa; 
        //private void Update()
        //{
        //    angle = aaa;
        //    newposition = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radiusRange;
        //    opponentPlayer.transform.position = newposition;
        //}
        //////////dummy, to take angles of Opponent;//////////




    }
}

