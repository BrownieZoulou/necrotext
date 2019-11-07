using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Formules : MonoBehaviour
{
    public Text form;
    public Button btnOuvrirGrimoire;
    public Button btnFermerGrimoire;
    public Button btnPause;
    public GameObject grimoire;
    public GameObject menuPause;
    public string[] listFormules;
    public int taillePlusLongueFormule = 1;
    public string formuleEnConstruction;

    // Start is called before the first frame update
    void Start()
    {
        /* 
        Génération des formules dans le grimoire ? 
            pour chaque formule, Menu.text = formule[i] --> affiche les formules les unes en dessous des autres dans le menu
        */
        listFormules = new string[] {"abra", "kada", "bra", "azerty"};
        print("Taille de la liste de formules : " + listFormules.Length);
        
        // On cherche à trouver la formule la plus longue
        for(int i = 0; i < listFormules.Length; i++){
            listFormules[i] = listFormules[i].ToUpper(); // On met toutes les formules en majuscule
            print("Start mot : " + listFormules[i]);
            if(taillePlusLongueFormule < listFormules[i].Length){
                taillePlusLongueFormule = listFormules[i].Length;
            }
        }
        print("taillePlusLongueFormule = " + taillePlusLongueFormule); 

        // On cache le grimoire et le bouton pause au début 
        grimoire.gameObject.SetActive(false); 

        formuleEnConstruction = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si une touche est tapée et que le grimoire est fermé et que le jeu n'est pas sur pause
        if (Input.anyKeyDown && !grimoire.gameObject.activeSelf && !menuPause.gameObject.activeSelf){ 
            string keyPressed = Input.inputString.ToUpper(); // On met en majuscule le caractère qui vient d'être saisi
            print("--------------------------------------------------------------------------");
            print("Key pressed = " + keyPressed);

            // On cherche à savoir si la touche entrée est une lettre
            char c;
            try{
                c = char.Parse(keyPressed);
            }catch(Exception e){
                print("ERROR : " + e.Message);
                c = '1'; // Pour éviter de rentrer dans la condition d'après si ce n'est pas une lettre qui est saisie
            }
            
            if((c>='A' && c<='Z') || (c>='a' && c<='z')){ // Si le caractère saisi est une lettre
                print("C'est une lettre !");
                formuleEnConstruction += keyPressed;
                form.text = formuleEnConstruction;
                print("Formule en construction = " + formuleEnConstruction);

                // On vérifie que le champ de texte est nul pour éviter les itérations inutiles
                if(formuleEnConstruction != ""){                
                    // Pour chacunes des formules
                    bool formuleTrouvee = false;
                    string formuleExistante = "";
                    for(int i = 0; i < listFormules.Length; i++){

                        // On compare la formule qui est en train d'être écrite avec le début des formules du grimoire
                        // Par exemple : si le joueur a saisi les 2ères lettres d'une formule, on compare ces 2ères lettres à toutes les 2ères lettres des autres formules
                        // Si au moins une est identique / correspond
                        //     --> On continue de tester avec plus de lettre pour voir si la formule existe toujours
                        // Si les premières lettres saisies par le joueur ne sont identiques à aucune des premières lettres d'une formule du grimoire
                        //     --> Le joueur s'est trompé car la formule n'existe pas et donc ça clean le mot
                        if(formuleEnConstruction.Length <= listFormules[i].Length){
                            formuleExistante = listFormules[i].Substring(0, formuleEnConstruction.Length); // On récupère le même de nombre de lettres des 2 formules à comparer
                            print("formuleExistante = " + formuleExistante);
                        }else{
                            print("Formule saisie + grande que formule de base");
                        }

                        // Lettres saisies identiques aux lettres d'une formule ? Si oui, on continue, sinon on clear
                        if(formuleEnConstruction == formuleExistante){
                            formuleTrouvee = true;
                        }

                    }

                    if(formuleTrouvee){
                        print("formuleEnConstruction == formuleExistante --> ok");
                        for(int i = 0; i < listFormules.Length; i++){
                            // Si la formule en train d'être écrite correspond parfaitement à une des formules existantes (si le joueur a fini d'écrire sa formule)
                            // On fait spawn en fonction de cette formule
                            if(formuleEnConstruction == listFormules[i]){
                                print("FORMULE COMPLETE ----> ON FAIT SPAWN AVEC LA FORMULE");
                                cleanFormule();
                            }   
                        }
                    }else{
                        print("formuleEnConstruction != formuleExistante --------> on clear car formule erronée");
                        cleanFormule(); 
                    }
                }
            }else{
                print("Ce n'est pas une lettre !");
            }
        }
    }

    // Méthode permettant de réinitialiser le champ de texte et de garder le focus sur le champ de texte
    public void cleanFormule(){
        formuleEnConstruction = "";
        form.text = "";
        //formule.ActivateInputField();
    }
    
    public void ouvrirGrimoire(){
        print("Ouverture du grimoire !");
        grimoire.gameObject.SetActive(true);
        btnOuvrirGrimoire.gameObject.SetActive(false);
        btnPause.gameObject.SetActive(false);
    }

    public void fermerGrimoire(){
        print("Fermeture du grimoire !");
        grimoire.gameObject.SetActive(false);
        btnOuvrirGrimoire.gameObject.SetActive(true);
        btnPause.gameObject.SetActive(true);    
    }

    public void mettreEnPause(){
        menuPause.gameObject.SetActive(true);
        btnPause.gameObject.SetActive(false);
        // On stop tout le jeu
        Time.timeScale = 0f;
    }

    public void reprendreJeu(){
        menuPause.gameObject.SetActive(false);
        btnPause.gameObject.SetActive(true);
        // On reprend le jeu
        Time.timeScale = 1f;
    }

    public void recommencerJeu(){
        reprendreJeu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitterJeu(){
        print("Le jeu se termine.");
        Application.Quit();
    }
}
