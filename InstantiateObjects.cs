public class InstantiateObjects : MonoBehaviour
{
    public GameObject myPrefab;
    float x_RandomLocation;
    float z_RandomLocation;
    Vector3 spawnPositions;

    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            x_RandomLocation = Random.Range(-13.0f, 13.0f);
            z_RandomLocation = Random.Range(-13.0f, 13.0f);
            spawnPositions = new Vector3(x_RandomLocation,       //x casuale
                                         0.5f,                   //y fissa
                                         z_RandomLocation);      //z casuale

            Instantiate(myPrefab, spawnPositions, Quaternion.identity);
        }
    }
}