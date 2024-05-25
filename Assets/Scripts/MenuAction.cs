
using UnityEngine;


//las siguientes librerías son necesarias para el uso de XR
public class MenuAction : MonoBehaviour
{  private bool menuButtonPreviousState = false;
    //menu
    public GameObject menu;
    //Esta variable se establece en el inspector y se asigna a un objeto de tipo AudioSource en el menú de categorías
    public AudioSource sound;
 
    public GameObject[] sites;
    public GameObject[] categories;
    //cambio de categoria en dropdown
     public void ChangeCategory(int num){
        Debug.Log("Category: " + num);
        for( int i = 0; i<categories.Length; i++){
            if(i == num){
                categories[i].SetActive(true);  
            }else{           
                categories[i].SetActive(false);
            }     
        }
        
        Debug.Log("Category: " + categories[num].name);
  }
    //Cambio de sitio
    public void GoSite(int num){
        for( int i = 0; i<sites.Length; i++){
         if(i == num){
               sites[i].SetActive(true);  
            }else{           
                sites[i].SetActive(false);
            }    
           
        }
        Debug.Log("Site: " + sites[num].name);
    }
//Reproducir sonido
     public void playButton(){
    sound.Play();
   }
   
  //Menu
  void Start()
    {
       GoSite(0);
    }

    void Update()
    {  //Ya que update se ejecuta una vez por frame, se puede usar para detectar el cambio de estado del botón
        bool menuButtonCurrentState;
        if (UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out menuButtonCurrentState))
        {
          
            if (menuButtonCurrentState && !menuButtonPreviousState)
            {
                Debug.Log("Menu button pressed!");
                //Desactivar o activar el menu
                if(menu != null)
                {
                    menu.SetActive(!menu.activeSelf);
                }
    
            }
            
            menuButtonPreviousState = menuButtonCurrentState;
        }
    }

   
}
