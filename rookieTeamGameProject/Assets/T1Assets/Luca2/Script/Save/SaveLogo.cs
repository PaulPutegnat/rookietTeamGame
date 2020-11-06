using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveLogo
{
    public int logo1;
    public int logo2;
    

    public SaveLogo (LogoSystem logoSystem){
        logo1 = logoSystem.logo1;
        logo2 = logoSystem.logo2;
        
    }
 
}
