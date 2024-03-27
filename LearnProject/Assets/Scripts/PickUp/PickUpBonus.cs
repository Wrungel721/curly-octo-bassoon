using LearnProject.Items;
using LearnProject.Shooting;
using UnityEngine;

namespace LearnProject.PickUp
{
    public class PickUpBonus : PickUpItem
    {
        [SerializeField]
        private SpeedBonus _bonusPrefab;

        public override void PickUp(BaseCharacter character)
        {
            base.PickUp(character);
            Debug.Log("!!!!");
            //character.SetBonus(_bonusPrefab);
        }
    }
}