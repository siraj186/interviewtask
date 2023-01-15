using System;

namespace RaceForDiamond
{
    public interface ICommand
    {
        Action OnFinished { get; set; }
        void Execute();
    }

}