using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    #region LoadLevel
    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LoadLevel(string s)
    {
        SceneManager.LoadScene(s);
    }
    #endregion

    #region Pause
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void AfterPause()
    {
        Time.timeScale = 1;
    }
    #endregion

    private void Start()
    {
        if ((collidersParaDesativar == null || collidersParaDesativar.Count == 0) ||
            (collidersParaAtivar == null || collidersParaAtivar.Count == 0))
        {
            Debug.LogWarning("As listas de Colliders estão vazias ou não foram atribuídas no Inspector.");
            return;
        }

        // Começa a corrotina para alternar os colliders
        StartCoroutine(AlternarCollidersCoroutine());
    }

    void Update()
    {
        ESCPause();
    }

    #region ScreePause
    [Header("Screen Pause")]
    public GameObject screenPause;

    void ESCPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            screenPause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    #endregion

    #region Liga/DesligaColliders
    [Header("Colliders")]
    public List<Collider2D> collidersParaDesativar; // Lista de Colliders que serão desativados
    public List<Collider2D> collidersParaAtivar;    // Lista de Colliders que serão ativados

    private IEnumerator AlternarCollidersCoroutine()
    {
        // Espera 5 segundos antes da primeira alternância
        yield return new WaitForSeconds(5f);

        while (true)
        {
            // Desativa todos os colliders na lista 'collidersParaDesativar'
            foreach (Collider2D col in collidersParaDesativar)
            {
                col.enabled = false;
            }

            // Ativa todos os colliders na lista 'collidersParaAtivar'
            foreach (Collider2D col in collidersParaAtivar)
            {
                col.enabled = true;
            }

            // Espera 5 segundos antes de alternar novamente
            yield return new WaitForSeconds(5f);

            // Troca as listas para que a lista de ativação se torne a de desativação e vice-versa
            List<Collider2D> temp = collidersParaDesativar;
            collidersParaDesativar = collidersParaAtivar;
            collidersParaAtivar = temp;
        }
    }
    #endregion
}
