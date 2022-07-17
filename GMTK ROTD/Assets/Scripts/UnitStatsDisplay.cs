using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatsDisplay : MonoBehaviour
{
    public UnitScrptObjct unit;
    public Text nameText;
    public Text healthText;
    public Text attackText;
    public Text speedText;
    // Start is called before the first frame update
    void Start()
    {
     unit.Print();

        
    }
}
