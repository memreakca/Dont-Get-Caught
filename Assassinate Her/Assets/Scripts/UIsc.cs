using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIsc : MonoBehaviour
{
    [SerializeField] private Image cdImage;

 
    private void Cooldowns()
    {
        if (( AsassinMovement.main.timelastInvis / AsassinMovement.main.invisCd) >= 1)
        {
            cdImage.fillAmount = 0f;
        }
        else
        { cdImage.fillAmount = 1 - AsassinMovement.main.timelastInvis / AsassinMovement.main.invisCd; }
    }
    private void Update()
    {
        Cooldowns();
    }
}
