using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseHero : MonoBehaviour
{
    public Animator animator;
    public GameObject okButton;
    public GameObject ManLight;
    public GameObject WomenLight;
    private void Start()
    {
        animator = GetComponent<Animator>();
        okButton.GetComponent<GameObject>();
        WomenLight.GetComponent<GameObject>();
        ManLight.GetComponent<GameObject>();
    }
    private void OnMouseDown()
    {
        string sexHero = gameObject.name.ToString();
        PlayerInformationStatic.PrefabHero = sexHero;
        if (sexHero == "Women")
        {
            ManLight.SetActive(false);
            WomenLight.SetActive(true);
        }
        else if(sexHero == "Man")
        {
            WomenLight.SetActive(false);
            ManLight.SetActive(true);
        }
        animator.SetTrigger("Choice");
        okButton.SetActive(true);
    }
}
