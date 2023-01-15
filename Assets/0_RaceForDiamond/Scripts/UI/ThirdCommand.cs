using System;

namespace RaceForDiamond
{
    public class ThirdCommand : ICommand
    {
        private readonly HelpHandler _owner;


        public Action OnFinished { get; set; }
        public ThirdCommand(HelpHandler helpHandler)
        {
            _owner = helpHandler;
        }

        public void Execute()
        {
            _owner.thirdPopup.gameObject.SetActive(true);

            _owner.thirdPopup.onClose += OnClose;
        }

        private void OnClose()
        {
            _owner.thirdPopup.onClose -= OnClose;
            _owner.thirdPopup.gameObject.SetActive(false);
            OnFinished?.Invoke();
        }
    }

}