using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RaceForDiamond
{
    public class Popup : MonoBehaviour
    {
        public Action onClose;


        public void Close()
        {
            onClose?.Invoke();
        }
    }
}
