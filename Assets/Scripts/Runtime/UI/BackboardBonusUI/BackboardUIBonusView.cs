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
            Color bonusColor = Color.white;
            switch (bonusType)
            {
                case BonusTypeEnum.FourPoints:
                    bonusColor = Color.yellow;
                    break;
                case BonusTypeEnum.SixPoints:
                    bonusColor = Color.cyan;
                    break;
                case BonusTypeEnum.EightPoints:
                    bonusColor = Color.magenta;
                    break;
                case BonusTypeEnum.None:
                default:
                    _bonusImage.enabled = false;
                    _bonusText.enabled = false;
                    return;
            }
            _bonusImage.enabled = true;
            _bonusText.enabled = true;
            _bonusImage.color = bonusColor;
            _bonusText.text = $"+{(int)bonusType}";
        }
    }
}