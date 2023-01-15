using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace RaceForDiamond
{
    public class CommandQueue
    {
        private readonly Queue<ICommand> _queue;

        private bool _isPending;

        public CommandQueue()
        {
            _queue = new Queue<ICommand>();
            _isPending = false;
        }

        public void Enqueue(ICommand cmd)
        {
            _queue.Enqueue(cmd);

            if (!_isPending)
                DoNext();
        }

        public void DoNext()
        {
            if (_queue.Count == 0)
            {
                UIHandler uihandler = GameManager.Instance.uihandler;
                uihandler.EnableStartButton();
                return;
            }

            var cmd = _queue.Dequeue();
            _isPending = true;
            cmd.OnFinished += OnCmdFinished;
            cmd.Execute();
        }

        private void OnCmdFinished()
        {
            _isPending = false;
            DoNext();
        }
    }

}