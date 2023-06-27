using System;

namespace Task_2_1
{
    public interface IСontrolController
    {
        event EventHandler Touch;
        void UpData();
        void Dispose();
    }
}