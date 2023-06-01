using UnityEngine;

namespace CodeBase.Services.Input
{
    public class InputService : IInputService
    {
        public bool IsFire => UnityEngine.Input.GetKeyDown(KeyCode.Space);
    }
}