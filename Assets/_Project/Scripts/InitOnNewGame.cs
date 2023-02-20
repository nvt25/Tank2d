using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitOnNewGame : MonoBehaviour
{
    [System.Serializable]
    public class infoBullet
    {
        public string nameBullet;
        public BulletController bulletPrefab;
        public int totalBullet;
    }
    [System.Serializable]
    public class infoVFX
    {
        public string nameVFX;
        public GameObject VFXPrefab;
        public int totalVFX;
    }
    public GameObject coinPrefab;
    public GameObject tankVestigePrefab;
    public static InitOnNewGame Ins;
    public List<infoBullet> listBulletsPrefab;
    public List<infoVFX> listVFXsPrefab;
    public Dictionary<string, Queue<BulletController>> bullets;
    public Dictionary<string, Queue<GameObject>> VFX_Anim;
    public Queue<GameObject> coins;
    public Queue<GameObject> TankVistige;
    private void Awake()
    {
        Ins = this;
    }
    void Start()
    {
        bullets = new Dictionary<string, Queue<BulletController>>();
        foreach (infoBullet bullet in listBulletsPrefab)
        {
            Queue<BulletController> tenmpBullet = new Queue<BulletController>();
            for (int i = 0; i < bullet.totalBullet; i++)
            {
                BulletController tempBullet = Instantiate(bullet.bulletPrefab);

                tempBullet.gameObject.SetActive(false);
                tenmpBullet.Enqueue(tempBullet);
            }
            bullets.Add(bullet.nameBullet, tenmpBullet);
        }
        //Debug.Log("Helllo");
        VFX_Anim = new Dictionary<string, Queue<GameObject>>();
        foreach (infoVFX a in listVFXsPrefab)
        {
            Queue<GameObject> bb = new Queue<GameObject>();
            for (int i = 0; i < a.totalVFX; i++)
            {
                GameObject tempVFX = Instantiate(a.VFXPrefab);
                tempVFX.gameObject.SetActive(false);
                bb.Enqueue(tempVFX);
            }
            VFX_Anim.Add(a.nameVFX, bb);
        }
        //Debug.Log(VFX_Anim.Count);
        coins = new Queue<GameObject>();
        for (int i = 0; i < 50; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.name = temp.name + i;
            temp.SetActive(false);
            coins.Enqueue(temp);
        }
        TankVistige = new Queue<GameObject>();
        for (int i = 0; i < 150; i++)
        {
            GameObject temp = Instantiate(tankVestigePrefab);
            temp.name = temp.name + i;
            temp.SetActive(false);
            TankVistige.Enqueue(temp);
        }
    }

    public void SpanwBullet(string nameBullet, Transform location)
    {
        if (bullets.ContainsKey(nameBullet))
        {
            BulletController bullet = bullets[nameBullet].Dequeue();
            bullet.gameObject.SetActive(true);
            bullet.transform.position = location.position;
            bullet.transform.rotation = location.rotation;
            bullet.Shoot(0.01f, location);
            bullets[nameBullet].Enqueue(bullet);

        }
    }
    public void SpanwVfx(string nameVFX, Transform location)
    {
        if (VFX_Anim.ContainsKey(nameVFX))
        {
            GameObject bullet = VFX_Anim[nameVFX].Dequeue();
            bullet.gameObject.SetActive(false);
            bullet.gameObject.SetActive(true);
            bullet.transform.position = location.position;
            bullet.transform.rotation = location.rotation;
            VFX_Anim[nameVFX].Enqueue(bullet);

        }
    }
    public void spawCoin(Vector2 location)
    {
        GameObject tempCoin = coins.Dequeue();
        tempCoin.gameObject.SetActive(false);
        tempCoin.gameObject.SetActive(true);
        tempCoin.transform.position = location;
        coins.Enqueue(tempCoin);
    }
    public void spawTankVestige(Transform location)
    {
        GameObject temp = TankVistige.Dequeue();
        temp.gameObject.SetActive(false);
        temp.gameObject.SetActive(true);
        temp.transform.position = location.position;
        temp.transform.rotation = location.rotation;
        TankVistige.Enqueue(temp);
    }
    public void ResetNew()
    {
        foreach(infoBullet typeBullet in listBulletsPrefab)
        {
            if (bullets.ContainsKey(typeBullet.nameBullet))
            {
                foreach(BulletController temp in bullets[typeBullet.nameBullet])
                {
                    temp.gameObject.SetActive(false);
                }
            }
        }
        foreach (infoVFX typeVFX in listVFXsPrefab)
        {
            if (VFX_Anim.ContainsKey(typeVFX.nameVFX))
            {
                foreach (GameObject temp in VFX_Anim[typeVFX.nameVFX])
                {
                    temp.SetActive(false);
                }
            }
        }
        foreach(GameObject temp in coins)
        {
            temp.SetActive(false);
        }
        foreach(GameObject temp in TankVistige)
        {
            temp.SetActive(false);
        }
    }
}
