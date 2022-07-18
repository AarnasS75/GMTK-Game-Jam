using UnityEngine;
using RealmNameConstants;   // Realm name constants namespace

public class RealmsDesigner : MonoBehaviour
{
    [SerializeField] private Light sceneLight;
    [SerializeField] private GameObject level;

    [SerializeField] private RealmSettings[] realms;
    [SerializeField] GameObject[] realmProps;
    [SerializeField] AudioSource[] musicSources;

    Vector3 groundSize;

    private void Awake()
    {
        DiceFaceCheck.OnDiceStop += ChangeRealm;
    }
    private void Start()
    {
        //groundSize = GetLevelGroundSize() / 2;
        CreateRealm(RealmName.Hell);
    }
    // ----- Use RealmNameConstants.RealmName ------
    void ChangeRealm(int value)
    {
        //switch (value)
        //{
        //    case 15:
        //    case 20:
        //        CreateRealm(RealmName.Hell);
        //        break;
        //    case 30:
        //    case 40:
        //        CreateRealm(RealmName.Normal);
        //        break;
        //    case 50:
        //    case 60:
        //        CreateRealm(RealmName.Heaven);
        //        break;
        //}


        //Debug.Log(value);

        if (value == 15)
        {
            CreateRealm(RealmName.Normal);
        }
        else if (value == 20)
        {
            CreateRealm(RealmName.Hell);
        }
        else if (value == 30)
        {
            CreateRealm(RealmName.Hell);
        }
        else if (value == 40)
        {
            CreateRealm(RealmName.Normal);
        }
        else if (value == 50)
        {
            CreateRealm(RealmName.Normal);
        }
        else if (value == 60)
        {
            CreateRealm(RealmName.Heaven);
        }
    }

    void CreateRealm(string newRealmName)
    {
        foreach (var realm in realms)
        {
            if (newRealmName == RealmName.Hell)
            {
                realmProps[0].SetActive(true);
                realmProps[1].SetActive(false);
                realmProps[2].SetActive(false);
                musicSources[0].Play();
                musicSources[1].Stop();
                SetLightColor(realms[0].realmLightColor);
                ChangeGroundMaterial(realms[0].groundMaterial);
                SetSkyboxMaterial(realms[0].skybox);
                //CreateRealmScenery(realms[0].objectsToSpawnOnGround, realms[0].objectAmmount);
            }
            if (newRealmName == RealmName.Normal)
            {
                musicSources[0].Stop();
                musicSources[1].Stop();
                realmProps[0].SetActive(false);
                realmProps[1].SetActive(true);
                realmProps[2].SetActive(false);
                SetLightColor(realms[1].realmLightColor);
                ChangeGroundMaterial(realms[1].groundMaterial);
                //SetSkyboxMaterial(realms[1].skybox);
                //CreateRealmScenery(realms[1].objectsToSpawnOnGround, realms[1].objectAmmount);
            }
            if (newRealmName == RealmName.Heaven)
            {
                musicSources[0].Stop();
                musicSources[1].Play();
                realmProps[0].SetActive(false);
                realmProps[1].SetActive(false);
                realmProps[2].SetActive(true);
                SetLightColor(realms[2].realmLightColor);
                ChangeGroundMaterial(realms[2].groundMaterial);
                SetSkyboxMaterial(realms[2].skybox);
                //CreateRealmScenery(realms[2].objectsToSpawnOnGround, realms[2].objectAmmount);
            }
        }
    }
    #region Design Instructions

    void SetLightColor(Color realmColor)
    {
        sceneLight.color = realmColor;
    }

    void ChangeGroundMaterial(Material realmGroundMaterial)
    {
        if (level.transform.childCount > 0)
        {
            for (int i = 0; i < level.transform.childCount; i++)
            {
                if (level.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    level.transform.GetChild(i).GetComponent<MeshRenderer>().material = realmGroundMaterial;
                }
            }
        }
        else
        {
            level.GetComponent<MeshRenderer>().material = realmGroundMaterial;
        }
    }
    void SetSkyboxMaterial(Material realmSkybox)
    {
        RenderSettings.skybox = realmSkybox;
    }
    void CreateRealmScenery(Transform[] realmObjects, int objectAmmount)
    {
        if (transform.childCount > 0)
            DeleteOldObjects();

        for (int i = 0; i < objectAmmount; i++)
        {
            Vector3 randomSpawnPos = new Vector3
            {
                x = Random.Range(-groundSize.x, groundSize.x),
                y = Random.Range(-groundSize.y, groundSize.y),
                z = Random.Range(-groundSize.z, groundSize.z),
            };

            Instantiate(realmObjects[Random.Range(0, realmObjects.Length)], randomSpawnPos, Quaternion.identity, transform);
        }
    }
    #endregion

    Vector3 GetLevelGroundSize()
    {
        Vector3 groundSize = Vector3.zero;

        if (level.transform.childCount > 0)
        {
            for (int i = 0; i < level.transform.childCount; i++)
            {
                groundSize += level.transform.GetChild(i).GetComponent<Collider>().bounds.size;
            }
        }
        else
        {
            groundSize = level.GetComponent<Collider>().bounds.size;
        }
        return groundSize;
    }
    void DeleteOldObjects()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}