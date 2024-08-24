using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    [Header("Colliders")]
    public List<Collider2D> collidersParaDesativar; // Lista de Colliders que ser�o desativados
    public List<Collider2D> collidersParaAtivar;    // Lista de Colliders que ser�o ativados

    private void Start()
    {
        if ((collidersParaDesativar == null || collidersParaDesativar.Count == 0) ||
            (collidersParaAtivar == null || collidersParaAtivar.Count == 0))
        {
            Debug.LogWarning("As listas de Colliders est�o vazias ou n�o foram atribu�das no Inspector.");
            return;
        }

        // Come�a a corrotina para alternar os colliders
        StartCoroutine(AlternarCollidersCoroutine());
    }

    private IEnumerator AlternarCollidersCoroutine()
    {
        // Espera 5 segundos antes da primeira altern�ncia
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

            // Troca as listas para que a lista de ativa��o se torne a de desativa��o e vice-versa
            List<Collider2D> temp = collidersParaDesativar;
            collidersParaDesativar = collidersParaAtivar;
            collidersParaAtivar = temp;
        }
    }
}
