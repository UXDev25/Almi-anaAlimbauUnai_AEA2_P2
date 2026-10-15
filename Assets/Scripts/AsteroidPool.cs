using System.Collections.Generic;
using UnityEngine;

// TODO: la mateixa estructura que el bullet pool.
public class AsteroidPool : MonoBehaviour
{
    public static AsteroidPool Instance;

    [SerializeField] private Asteroid asteroidPrefab;
    [SerializeField] private int initialSize = 15;

    private Stack<Asteroid> pool = new Stack<Asteroid>();

    private void Awake()
    {
		// TODO:
		//   Singleton.
		//   Fer les comprovacions necessàries perquè només hi hagi una instància d'aquest singleton 
		// TODO:Inicialitza aquí la Pool amb base que es farà servir. 
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
        for (int i = 0; i < initialSize; i++)
        {
            Asteroid asteroid = CreateAsteroid();
            pool.Push(asteroid);
        }
    }

    private Asteroid CreateAsteroid()
    {
        // TODO:
        //   Instància els prefabs recorda que els has d'instanciar desactivats.
        //   Fixeu-vos que el mètode ha de retornar un Asteroid
        Asteroid newAsteroid = Instantiate(asteroidPrefab);
        newAsteroid.gameObject.SetActive(false);
        return newAsteroid;
    }

    public Asteroid GetAsteroid(Vector3 position)
    {
        // TODO:
        //   si l'stack no esta buit (pool.Count > 0), treu un Asteroid Pop().
        //   si no en queda cap instancia un CreateAsteroid().
        //   col·loca en la posició correcta, activa'l i retorna'l
        if (pool.Count <= 0) CreateAsteroid();
        Asteroid newAsteroid = pool.Pop();
        newAsteroid.gameObject.SetActive(true);
        newAsteroid.gameObject.transform.position = position;
        return newAsteroid;
    }

    public void ReturnAsteroid(Asteroid asteroid)
    {
        // TODO:
        //   Desactiva l'asteroid i torna'l al stack Push().
        asteroid.gameObject.SetActive(false);
        pool.Push(asteroid);
    }
}
