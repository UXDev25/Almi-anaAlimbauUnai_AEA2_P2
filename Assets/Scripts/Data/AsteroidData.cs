using UnityEngine;
// TODO: crea el ScriptableObject [CreateAssetsMenu...] recorda que no ha d'heretar de MonoBehaviour
[CreateAssetMenu(fileName = "NewAsteroidData", menuName = "Asteroids/Asteroid Data")]
public class AsteroidData : ScriptableObject
{
	public float minSpeed = 2;
	public float maxSpeed = 3;
	public float scale = 1;
	public int maxHealth = 100;
	public int scoreValue = 50;
	public int damage = 1;
	public Color color = Color.white;
}
