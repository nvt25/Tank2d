using UnityEngine;
[CreateAssetMenu(fileName = "PlayerModel", menuName = "ScriptableObjects/PlayerModel", order = 1)]
public class PlayerMode : ScriptableObject
{
    [SerializeField]
    private int codeId;
    [SerializeField]
    private string nameModel;
    [SerializeField]
    private string typeBullet;
    [SerializeField]
    private int priceCoint;
    [SerializeField]
    private float percentDamage;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private int status;

    public int CodeID{ get => codeId; }
    public string NameModel { get => nameModel; }
    public string TypeBullet { get => typeBullet; }
    public float PercentDamage { get => percentDamage; }
    public int PriceCoint { get => priceCoint;}
    public Sprite Sprite { get => sprite; }
    public int Status
    {
        get => status;
        set => status = value;
    }
}
