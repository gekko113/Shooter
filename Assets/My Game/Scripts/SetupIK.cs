using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace My_Game.Scripts
{
    public class SetupIK : MonoBehaviour
    {
        [Header("Constraints")] [SerializeField]
        private TwoBoneIKConstraint rightHandConstraint;

        [SerializeField] private TwoBoneIKConstraint leftHandConstraint;

        [Header("Rig Settings")] [SerializeField]
        private RigBuilder rigBuilder;

        public void BindWeaponIK(WeaponRigTargets weaponTargets)
        {
            if (weaponTargets == null)
            {
                ResetIK();
                return;
            }

            var rightData = rightHandConstraint.data;
            rightData.target = weaponTargets.rightTarget;
            rightHandConstraint.data = rightData;
            var leftData = leftHandConstraint.data;
            leftData.target = weaponTargets.leftTarget;
            leftHandConstraint.data = leftData;
            rigBuilder.Build();
        }

        public void ResetIK()
        {
            var rightData = rightHandConstraint.data;
            rightData.target = null;
            rightData.hint = null;
            rightHandConstraint.data = rightData;

            var leftData = leftHandConstraint.data;
            leftData.target = null;
            leftData.hint = null;
            leftHandConstraint.data = leftData;

            rigBuilder.Build();
        }
    }
}