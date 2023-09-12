using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAble
{
    void TakeDamage(float damageRecieved);
}

public interface IHealable
{
    void Healed(float healthToHeal);
}
