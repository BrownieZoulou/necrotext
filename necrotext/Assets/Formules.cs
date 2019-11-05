using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Formules : MonoBehaviour
{
    public InputField formule;
    public GameObject grimoire;
    public string[] listFormules = {"abra", "kada", "bra"};

    // Start is called before the first frame update
    void Start()
    {
        /* 
        Génération des formules dans le grimoire ? 
            pour chaque formule, Menu.text = formule[i] --> affiche les formules les unes en dessous des autres dans le menu
        */
    }

    // Update is called once per frame
    void Update()
    {

        // On vérifie que le champ de texte est nul pour éviter les itérations inutiles
        if(!string.IsNullOrEmpty(formule.text)){
            print("---------------------------------------------");
            print("Formule saisie : " + formule.text);
            print("Taille de la liste de formules : " + listFormules.Length);
        }

        if(Input.GetKeyDown("return")){
            print("---------------------------------------------");
            print("Formule saisie : " + formule.text);
            print("Taille de la liste de formules : " + listFormules.Length);

            // On cherche à savoir si la formule saisie est présente dans la liste des formules existantes
            bool formuleTrouvee = false;
            for(int i = 0; i < listFormules.Length; i++){
                if(formule.text == listFormules[i]){
                    formuleTrouvee = true;
                }   
            }

            // Si on a trouvé la formule, on fait spawn en fonction de celle-ci
            // Sinon, on indique que la formule est erronnée
            if(formuleTrouvee){
                print("Formule existante : " + formule.text + " ------> faire spawn");
            }else{
                print("Formule erronée");                
            }

            // On réinitialise le champ de texte et on garde le focus sur le champ de texte
            formule.text = "";
            formule.ActivateInputField ();        
        }
        else if(Input.GetKeyDown(KeyCode.Tab)){
             print("TAB pressed");

             if(grimoire.gameObject.activeSelf){
                print("Grimoire ouvert ? --> On le ferme");
                grimoire.gameObject.SetActive(false);
             }else{
                print("Grimoire fermé ? --> On l'ouvre'");
                grimoire.gameObject.SetActive(true);
             }
         }
    }
}
