using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MonsterController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GenericSingleton<MonsterFactory>.getInstance().SummonMonster();
        }
    }
}
  


