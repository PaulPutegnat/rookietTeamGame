using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSystem : MonoBehaviour
{
    public int logo1;
    public int logo2;

    public void Start(){
        LoadLogo();
    }

    public void SaveLogo(){
        SaveSystem.saveLogo(this);
    }

    public void LoadLogo(){
        SaveLogo data = SaveSystem.LoadLogo();

        logo1 = data.logo1;
        logo2 = data.logo2;
        
    }
}
