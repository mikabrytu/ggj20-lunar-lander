﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Components
{
    public interface ICamera
    {
        void UpdateTargets(Transform newTarget);
    }
}
