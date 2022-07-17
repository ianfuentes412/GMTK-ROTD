using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitStatsDisplay : MonoBehaviour
{
    public UnitScrptObjct unit;
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text attackText;
    public TMP_Text speedText;
    // Start is called before the first frame update
    void Start()
    {
     unit.Print();

        
    }
}
