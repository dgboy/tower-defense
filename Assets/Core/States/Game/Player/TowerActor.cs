using System;
using Core.States.Game.Common;
using UnityEngine;

namespace Core.States.Game.Player {
    public class TowerActor : MonoBehaviour {
        [field: SerializeField] public Radar Radar { get; set; }
    }
}