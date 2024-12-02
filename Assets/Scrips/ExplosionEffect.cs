using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    public void Explode(Vector3 position)
    {
        // Instanciar el prefab de explosi�n en la posici�n dada
        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);

        // Destruir el prefab despu�s de 2 segundos para liberar memoria
        Destroy(explosion, 2f);
    }
}