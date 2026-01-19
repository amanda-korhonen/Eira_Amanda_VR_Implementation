using UnityEngine;

public class PotatoDistributer : MonoBehaviour { 

    //prefabs
    public GameObject GoodPotato;
    public GameObject BadPotato;

    //how many potatoes will be distributed all around
    public int goodAmount = 5;
    public int badAmount = 4;

    //define area (mud field size) where potatoes go
    public Vector3 areaSize = new Vector3(1, 1, 2);

    //audio 
    public AudioClip audioClip;
    public float audioVolume = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //call distribute at the beginnin of the game = distribute potatoes to the mud field
        Distribute(GoodPotato, goodAmount);
        Distribute(BadPotato, badAmount);
    }

    void Distribute(GameObject prefab, int count)
    {
        for (int i=0; i < count; i++)
        {
            //create a random position for the potato
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-areaSize.x / 2, areaSize.x / 2),
                0f,
                Random.Range(-areaSize.z / 2, areaSize.z / 2)
            );

            //apply the random position to the prefab
            Instantiate(prefab, randomPos, Quaternion.identity);
        }
    }
}
