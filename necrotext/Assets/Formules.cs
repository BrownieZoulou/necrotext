using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Formules : MonoBehaviour
{
    public InputField formule;
    public GameObject grimoire;
    public string[] listFormules;
    public int taillePlusLongueFormule = 1;

    // Start is called before the first frame update
    void Start()
    {
        /* 
        Génération des formules dans le grimoire ? 
            pour chaque formule, Menu.text = formule[i] --> affiche les formules les unes en dessous des autres dans le menu
        */
        listFormules = new string[] {"abra", "kada", "bra", "azerty", "az"};
        print("Taille de la liste de formules : " + listFormules.Length);
        
        // On cherche à trouver la formule la plus longue
        for(int i = 0; i < listFormules.Length; i++){
            if(taillePlusLongueFormule < listFormules[i].Length){
                taillePlusLongueFormule = listFormules[i].Length;
            }
        }
        print("taillePlusLongueFormule = " + taillePlusLongueFormule); 
        
    }

    // Update is called once per frame
    void Update()
    {

        // On vérifie que le champ de texte est nul pour éviter les itérations inutiles
        if(!string.IsNullOrEmpty(formule.text)){
            print("--------------------------------------------------------------------------");
            print("Formule saisie : " + formule.text);
            
            // Pour chacunes des formules
            bool formuleTrouvee = false;
            string motEnConstruction = "";
            for(int i = 0; i < listFormules.Length; i++){

                // On compare la formule qui est en train d'être écrite avec le début des formules du grimoire
                // Par exemple : si le joueur a saisi les 2ères lettres d'une formule, on compare ces 2ères lettres à toutes les 2ères lettres des autres formules
                // Si au moins une est identique / correspond
                //     --> On continue de tester avec plus de lettre pour voir si la formule existe toujours
                // Si les premières lettres saisies par le joueur ne sont identiques à aucune des premières lettres d'une formule du grimoire
                //     --> Le joueur s'est trompé car la formule n'existe pas et donc ça clean le mot
                if(formule.text.Length <= listFormules[i].Length){
                    motEnConstruction = listFormules[i].Substring(0, formule.text.Length); // On récupère le même de nombre de lettres des 2 formules à comparer
                    print("motEnConstruction = " + motEnConstruction);
                }else{
                    print("Formule saisie + grande que formule de base");
                }

                // Lettres saisies identiques aux lettres d'une formule ? Si oui, on continue, sinon on clear
                if(formule.text == motEnConstruction){
                    formuleTrouvee = true;
                }

            }

            if(formuleTrouvee){
                print("formule.text == motEnConstruction --> ok");
            }else{
                print("formule.text != motEnConstruction --------> on clear car formule erronée");
                cleanFormule(); 
            }
            
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

            cleanFormule();
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

    // Méthode permettant de réinitialiser le champ de texte et de garder le focus sur le champ de texte
    void cleanFormule(){
        formule.text = "";
        formule.ActivateInputField();
    }
}
