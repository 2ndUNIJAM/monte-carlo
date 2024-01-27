using MonteCarlo.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonteCarlo.Enemy
{
    public class RevolverToy : MonoBehaviour
    {
        // 1/6 -> 1/5 -> ...
        private int attackProb; // attack probablity

        void Start()
        {
            attackProb = 6;
        }


        void Update()
        {

        }
    }
}
