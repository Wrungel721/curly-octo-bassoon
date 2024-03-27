using System.Collections;
using LearnProject.Items;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace LearnProject.Movement
{
    public class SpeedBonusController : MonoBehaviour
    {
        public bool BonusActive = false;

        private float _bonusTimeSec = 0f;

        public float BonusMod = 0f;

        public void SetBonus(SpeedBonus Bonus)
        {
            BonusActive = true;
            _bonusTimeSec = Bonus.SpeedModifier;
            BonusMod = Bonus.ModifierTimer;

        }
        void Update()
        {
            if (_bonusTimeSec > 0)
            {
                _bonusTimeSec -= Time.deltaTime;
            }
            else
            {
                BonusMod = 0f;
                BonusActive = false;
            }
        }
    }
}