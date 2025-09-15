using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.UI.BackboardBonusUI
{
    public class BackboardUIBonusView : BaseUIView, IBackboardBonusUIView
    {
        [SerializeField] private TextMeshProUGUI _bonusText;
        [SerializeField] private Image _bonusImage;
        
        public void EnableBonus(BonusTypeEnum bonusType)
        {
            switch (bonusType)
            {

                case BonusTypeEnum.None:
                    _bonusImage.enabled = false;
                    _bonusText.enabled = false;
                    break;
                default:
                    _bonusImage.enabled = true;
                    _bonusText.enabled = true;
                    _bonusText.text = $"+{(int)bonusType}";
                    break;
            }
        }
    }
}