using UnityEngine;
using System.Collections;

public class MaterialsManager : MonoBehaviour {

    private Transform digletDo, digletRe, digletMi, digletFa, digletSol, digletLa, digletSi;

    public Material defaultDo;
    public Material defaultRe;
    public Material defaultMi;
    public Material defaultFa;
    public Material defaultSol;
    public Material defaultLa;
    public Material defaultSi;

    public Material NatalDo;
    public Material NatalRe;
    public Material NatalMi;
    public Material NatalFa;
    public Material NatalSol;
    public Material NatalLa;
    public Material NatalSi;

    public Material HalloweenDo;
    public Material HalloweenRe;
    public Material HalloweenMi;
    public Material HalloweenFa;
    public Material HalloweenSol;
    public Material HalloweenLa;
    public Material HalloweenSi;

    private string atualDigg;

    public Material grama, lapides;

    // Use this for initialization
    void Start() {
        atualDigg = PlayerPrefs.GetString("dig", "");

        digletDo = transform.FindChild("diglettDo");
        digletRe = transform.FindChild("diglettRe");
        digletMi = transform.FindChild("diglettMi");
        digletFa = transform.FindChild("diglettFa");
        digletSol = transform.FindChild("diglettSol");
        digletLa = transform.FindChild("diglettLa");
        digletSi = transform.FindChild("diglettSi");


        if (atualDigg == "Default") {
            digletDo.renderer.material = defaultDo;
            digletRe.renderer.material = defaultRe;
            digletMi.renderer.material = defaultMi;
            digletFa.renderer.material = defaultFa;
            digletSol.renderer.material = defaultSol;
            digletLa.renderer.material = defaultLa;
            digletSi.renderer.material = defaultSi;

        } else if (atualDigg == "Natal") {
            digletDo.renderer.material = NatalDo;
            digletRe.renderer.material = NatalRe;
            digletMi.renderer.material = NatalMi;
            digletFa.renderer.material = NatalFa;
            digletSol.renderer.material = NatalSol;
            digletLa.renderer.material = NatalLa;
            digletSi.renderer.material = NatalSi;

        } else if (atualDigg == "Halloween") {
            digletDo.renderer.material = HalloweenDo;
            digletRe.renderer.material = HalloweenRe;
            digletMi.renderer.material = HalloweenMi;   
            digletFa.renderer.material = HalloweenFa;
            digletSol.renderer.material = HalloweenSol;
            digletLa.renderer.material = HalloweenLa;
            digletSi.renderer.material = HalloweenSi;

        }
    }

    // Update is called once per frame
    void Update() {
    }
}
