using UnityEngine;
using RealmNameConstants;

[CreateAssetMenu(fileName = "Realm", menuName = "ScriptableObjects/RealmObject")]
public class RealmSettings : ScriptableObject
{
    [SerializeField]
    private Realm realmNames;

    [HideInInspector]
    public string realmName => realmNames.ToString();

    public Color realmLightColor;

    public Material groundMaterial;

    public Transform[] objectsToSpawnOnGround;

    public int objectAmmount;

    public Material skybox;
}
