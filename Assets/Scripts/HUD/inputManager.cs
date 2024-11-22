using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HUD
{
   public static class inputManager
   {
        public static bool IsInputLocked { get; private set; }

        public static void LockInput()
        {
            IsInputLocked = true;
        }

        public static void UnlockInput()
        {
            IsInputLocked = false;
        }
   } 
}

