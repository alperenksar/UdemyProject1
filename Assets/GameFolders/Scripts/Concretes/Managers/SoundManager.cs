using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject1.Controllers;
using UdemyProject1.Abstracts.Utilities;


namespace UdemyProject1.Managers
{
    public class SoundManager : SingletonThisObject<SoundManager>
    {
        private void Awake()
        {
            SingletonThisGameObject(this);

        }
    }

}
