using System.Collections;
using UnityEngine;

namespace RaceForDiamond
{
    public class HelpHandler : MonoBehaviour
    {
        public Popup firstPopup, secondPopup, thirdPopup;

        private CommandQueue _commandQueue;
        // Start is called before the first frame update
        void Start()
        {
            _commandQueue = new CommandQueue();
            StartCoroutine(StartCommandsCr());
        }

        private IEnumerator StartCommandsCr()
        {
            yield return new WaitForSeconds(1f);
            _commandQueue.Enqueue(new FirstCommand(this));
            _commandQueue.Enqueue(new SecondCommand(this));
            _commandQueue.Enqueue(new ThirdCommand(this));
        }
    }

}