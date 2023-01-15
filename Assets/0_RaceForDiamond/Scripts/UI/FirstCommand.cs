using System;

namespace RaceForDiamond
{
    public class FirstCommand : ICommand
    {
        private readonly HelpHandler _owner;


        public Action OnFinished { get; set; }
        public FirstCommand(HelpHandler helpHandler)
        {
            _owner = helpHandler;
        }

        public void Execute()
        {
            _owner.firstPopup.gameObject.SetActive(true);

            _owner.firstPopup.onClose += OnClose;
        }

        private void OnClose()
        {
            _owner.firstPopup.gameObject.SetActive(false);
            OnFinished?.Invoke();
            _owner.firstPopup.onClose -= OnClose;

        }
    }

}