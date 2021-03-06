﻿namespace LabyrinthBusinessLogic.Handlers.Displays
{
    /// <summary>
    ///     Interface for displays.
    /// </summary>
    public interface IDisplayHandler : Kabatra.Game.StateMachine.Handlers.Displays.IDisplayHandler
    {
        void DisplayStart();
        void DisplayVerticalPipe();
        void DisplayVerticalPipeModifier();
        void DisplayVerticalT();
        void DisplayHorizontalPipe();
        void DisplayHorizontalPipe2();
        void DisplayFlippedLeftAngle();
        void DisplayLeftAngle();
        void DisplayLeftAngleModifier();
        void DisplayFlippedHorizontalT();
        void DisplayFlippedRightAngle();
        void DisplayEnd();
    }
}
