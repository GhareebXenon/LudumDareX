using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HpSys
{
    public class Health
    {
        int currHealth;
        int maxHealth;

        public Health(int currHealth, int maxHealth)
        {
            this.currHealth = currHealth;
            this.maxHealth = maxHealth;
        }

        public int CurrHp
        {
            get
            {
                return currHealth;
            }
            set
            {
                currHealth = value;
            }
        }
        public int MaxHp
        {
            get
            {
                return maxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }

        public void HpDmg(int dmgPerCollision)
        {
            if (currHealth > 0)
            {
                currHealth -= dmgPerCollision;
            }
        }
    }
}
