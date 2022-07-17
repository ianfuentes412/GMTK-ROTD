using UnityEngine;

[CreateAssetMenu(fileName = "UnitScriptableObject", menuName = "ScriptableObject/unit1")]
public class UnitScrptObjct : ScriptableObject
{
    public new string name;
    public int health;
    public float speed;
    public int attack;

public void Print()
{
    Debug.Log(name);
    Debug.Log("Health: " + health);
    Debug.Log("Speed: " + speed);
    Debug.Log("Attack: " + attack);
}
}


