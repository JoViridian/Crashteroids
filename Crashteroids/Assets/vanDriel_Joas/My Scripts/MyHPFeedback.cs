using UnityEngine;
using TMPro;

public class MyHPFeedback : MonoBehaviour
{
    public MyHP hp;
    private int hpHere;
    public TextMeshProUGUI hpTextBox;
    public Color damageCol;
    public Color healCol;
    public Color protectedCol;
    public MyRushPowerUp rush;

    void Start()
    {
        hpHere = hp.hp;
    }

    void Update()
    {
        if (rush.rushState)
        {
            hpTextBox.color = (hpTextBox.color + protectedCol * Time.deltaTime) / (1 + Time.deltaTime);
        }
        else
        {
            hpTextBox.color = (hpTextBox.color + Color.white * Time.deltaTime) / (1 + Time.deltaTime);
        }

        if (hpHere < hp.hp)
        {
            hpTextBox.color = healCol;
            hpHere = hp.hp;
        }
        else if (hpHere > hp.hp)
        {
            hpTextBox.color = damageCol;
            hpHere = hp.hp;
        }
    }
}
