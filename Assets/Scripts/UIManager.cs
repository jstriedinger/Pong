using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] AudioClip selectSFX;
    // Start is called before the first frame update
    public void StartSinglePlayer()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("1P One");
    }

    public void ClickMultiplayer()
    {
        StartCoroutine(StartMultiplayer());
    }

    public IEnumerator StartMultiplayer()
    {
        AudioSource.PlayClipAtPoint(selectSFX, Camera.main.transform.position);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
