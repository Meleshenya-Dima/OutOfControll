using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Text ChooseYouHeroText;
    public Animator PanelAnimator;
    public Text ButtonText;

    public void ButtonChooseClick()
    {
        ChooseYouHeroText.GetComponent<Text>().enabled = false;
        ButtonText.GetComponent<Text>().text = "";
        StartCoroutine(OpenNewScene("StartGame", 2f, PanelAnimator.GetComponent<Animator>()));
    }

    public static IEnumerator OpenNewScene(string nameScene, float waitSecond, Animator animator)
    {
        animator.SetTrigger("Black");
        yield return new WaitForSeconds(waitSecond);
        SceneManager.LoadScene(nameScene);
    }

    public static void OpenMenu(Canvas canvas)
    {
        canvas.enabled = true;
    }

    public void RestartButtonClick() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void ExitButtonClick() => Application.Quit();
}
