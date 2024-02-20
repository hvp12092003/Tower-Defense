using TMPro;
using UnityEngine;

public class BoxInforEnemyController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Hp;
    [SerializeField] TextMeshProUGUI Speed;
    [SerializeField] TextMeshProUGUI DefPhysic;
    [SerializeField] TextMeshProUGUI DefMagic;

    public void DisplayInforTower(string name, string hp, string speed, string defP, string defM)
    {
        Name.text = "Name: " + name;
        Hp.text = "Hp: " + hp;
        Speed.text = "Damage: " + speed;
        DefPhysic.text = "DefPhysic: " + defP;
        DefMagic.text = "DefMagic:" + defM;
        MoveIUInGame.Instance.OnBoxInforEnemy();
    }
}
