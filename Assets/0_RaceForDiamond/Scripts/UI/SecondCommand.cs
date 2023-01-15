using System;

namespace RaceForDiamond
{
    public class SecondCommand : ICommand
    {
        private readonly HelpHandler _owner;


        public Action OnFinished { get; set; }
        public SecondCommand(HelpHandler helpHandler)
        {
            _owner = helpHandler;
        }

        public void Execute()
        {
            _owner.secondPopup.gameObject.SetActive(true);

            _owner.secondPopup.onClose += OnClose;
        }

        private void OnClose()
        {
            _owner.secondPopup.onClose -= OnClose;
            _owner.secondPopup.gameObject.SetActive(false);
            OnFinished?.Invoke();
        }
    }

}