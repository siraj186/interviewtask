using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

namespace RaceForDiamond
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private Button startBtn;
        [SerializeField] private Button replayBtn;
        [SerializeField] private GameObject helpObj;
        [SerializeField] private ResultPatch resultPatch;
        [SerializeField] private TextMeshProUGUI ranktxt;
        public static event Action<bool> OnRaceStart;

        public static Action<string> OnShowResultUI;

        void Start()
        {
            OnShowResultUI += ShowResultUI;
            startBtn.gameObject.SetActive(false);
        }

        public void EnableStartButton()
        {
            startBtn.gameObject.SetActive(true);
            startBtn.onClick.AddListener(StartTheRace);
        }

        public void EnableRestartButton()
        {
            replayBtn.gameObject.SetActive(true);
            replayBtn.onClick.AddListener(ReloadTheScene);
        }

        void StartTheRace()
        {
            OnRaceStart?.Invoke(true);
            helpObj.SetActive(false);
        }

        void ReloadTheScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDestroy()
        {
            OnShowResultUI -= ShowResultUI;
        }


        void ShowResultUI(string str)
        {
            resultPatch.gameObject.SetActive(true);
            ranktxt.text = str;
        }

    }

}