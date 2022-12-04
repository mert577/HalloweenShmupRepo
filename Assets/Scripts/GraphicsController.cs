using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GraphicsController : MonoBehaviour
{

   public  ParticleSystem damageParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DamageAnimation(Vector2 pos)
    {

        StartCoroutine(_());

        IEnumerator _(){

            SpawnParticle(damageParticle,pos);
            transform.DORewind();
            transform.DOPunchScale( transform.localScale* new Vector2(0.3f, 1.4f), .2f);
            var origcolor = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(.1f);
            GetComponent<SpriteRenderer>().color = origcolor;



        }




    }

    public void DeathAnimation()
    {
        DisableSprites();
    }


    public void DisableSprites()
    {
      var srs=  GetComponentsInChildren<SpriteRenderer>();

        foreach(SpriteRenderer sr in srs)
        {
            sr.enabled = false;
        }
    }


    void SpawnParticle(ParticleSystem ps, Vector2 pos)
    {
        ParticleSystem instance = Instantiate(ps, pos, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.startLifetime.constantMax);


    }
}
