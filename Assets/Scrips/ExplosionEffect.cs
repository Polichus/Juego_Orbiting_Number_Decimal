using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    public void Explode(Vector3 position)
    {
        // Instanciar el prefab de explosión en la posición dada
        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);

        // Destruir el prefab después de 2 segundos para liberar memoria
        Destroy(explosion, 2f);
    }
}