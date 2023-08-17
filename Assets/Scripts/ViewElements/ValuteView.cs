using Services;
using Services.Economic;
using UnityEngine;
using TMPro;

public class ValuteView : MonoBehaviour
{
    [SerializeField] private TMP_Text _valuteText;
    private IBankService _bank;
    private void OnEnable()
    {
        _bank = ServiceLockator.instance.GetService<IBankService>();
        _bank.OnValueChange += ChangeValute;
        ChangeValute(_bank.value);
    }

    private void OnDisable()
    {
        _bank.OnValueChange -= ChangeValute;
    }

    private void ChangeValute(int score)
    {
        _valuteText.text = score.ToString();
    }
}
