using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class T1ItemUiHandle : MonoBehaviour
{
    public List<Sprite> Armes = new List<Sprite>();
    public Image ImageWeapon;

    public int number;
    public int id;
    public bool done;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    public void getRandomweapon()
    {
        id = Random.Range(0, Armes.Count);
        ImageWeapon.sprite = Armes[id];
        if(number == 1){
        if(id == 0){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo1 = 0;
            text1.text = "Ecrase les ennemis pres de vous en face";
        }
        if(id == 1){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo1 = 1;
            text1.text = "Rebondit quand touche le sol";
        }
        if(id == 2){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo1 = 2;
            text1.text = "Lance la banane tout droit puis revient";
        }
        if(id == 3){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo1 = 3;
            text1.text = "Part en ligne droite rapidement";
        }
        if(id == 4){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo1 = 4;
            text1.text = "Avance en zigzag";
        }
        if(id == 5){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo1 = 5;
            text1.text = "Lance loin en cloche";
        }
        if(id == 6){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo1 = 6;
            text1.text = "Frappe devant soi";
        }
        }


        if(number == 2){
        if(id == 0){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo2 = 0;
            text2.text = "Ecrase les ennemis pres de vous en face";
        }
        if(id == 1){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo2 = 1;
            text2.text = "Rebondit quand touche le sol";
        }
        if(id == 2){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo2 = 2;
            text2.text = "Lance la banane tout droit puis revient";
        }
        if(id == 3){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo2 = 3;
            text2.text = "Part en ligne droite rapidement";
        }
        if(id == 4){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo2 = 4;
            text2.text = "Avance en zigzag";
        }
        if(id == 5){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo2 = 5;
            text2.text = "Lance loin en cloche";
        }
        if(id == 6){
            GameObject.Find("LogoSystem").GetComponent<LogoSystem>().logo2 = 6;
            text2.text = "Frappe devant soi";
        }
        }
        GameObject.Find("LogoSystem").GetComponent<LogoSystem>().SaveLogo();
        done = true;
    }
}