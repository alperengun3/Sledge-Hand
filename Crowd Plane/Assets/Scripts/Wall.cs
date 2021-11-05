using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wall : MonoBehaviour
{
    [SerializeField] PlayerSettings settings;
    [SerializeField] List<GameObject> bricks;
    [SerializeField] bool wallBool;
    MeshRenderer rend;
    GameObject targetPos;
    CamControl cam;
    public Collider childCollider;
    PlayerControl playerControl;
    void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        rend = GetComponent<MeshRenderer>();
        cam = FindObjectOfType<CamControl>();
    }

    void Update()
    {
        if (wallBool)
        {
            foreach (GameObject brick in bricks)
            {
                brick.transform.DOMove(new Vector3(targetPos.transform.position.x, targetPos.transform.position.y, targetPos.transform.position.z + 0.6f), 0.5f).OnComplete(() => brick.SetActive(false));
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(StringClass.TAG_SLEDGEHAMMER) && rend.sharedMaterial == playerControl.sledge.GetComponent<MeshRenderer>().sharedMaterial)
        {
            playerControl.anim.SetTrigger(StringClass.TAG_HIT);
            //settings.isLeftGlove = true;
            StartCoroutine(SledgeHit(other));
            GetComponent<Collider>().enabled = false;
        }

        if (other.CompareTag(StringClass.TAG_SLEDGEHAMMER) && rend.sharedMaterial != playerControl.sledge.GetComponent<MeshRenderer>().sharedMaterial)
        {
            playerControl.anim.SetTrigger(StringClass.TAG_STUNWALKING);
            Destroy(this.GetComponent<Collider>());
            other.transform.DOScale(new Vector3(other.transform.localScale.x - 0.5f, other.transform.localScale.y - 0.1f, other.transform.localScale.z - 0.05f), 1f);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            
            StartCoroutine(BrickScale(other));
            Invoke("DestrotWall", 5);
            cam.CamShake();
            Invoke("ScoreTime", 0.2f);
        }

    }
    private IEnumerator SledgeHit(Collider other)
    {
        yield return new WaitForSeconds (0.2f);
        settings.score++;
        Invoke("wallBoolTime", 0.75f);
        targetPos = other.gameObject;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.GetComponent<Collider>());
        StartCoroutine(BrickScale(other));
        foreach (GameObject brick in bricks)
        {
            brick.GetComponent<Rigidbody>().isKinematic = false;
            brick.GetComponent<Rigidbody>().useGravity = true;
            brick.GetComponent<BoxCollider>().enabled = true;
            brick.GetComponent<Collider>().isTrigger = false;
        }
        cam.CamShake();
        yield return new WaitForSeconds(0.9f);
        other.transform.DOScale(new Vector3(other.transform.localScale.x + 5f, other.transform.localScale.y + 1f, other.transform.localScale.z + 0.8f), 0.1f).
                OnComplete(() => other.transform.DOScale(new Vector3(other.transform.localScale.x - 4f, other.transform.localScale.y - 0.8f, other.transform.localScale.z - 0.7f), 0.2f));
    }

    void wallBoolTime()
    {
        wallBool = true;
    }

    IEnumerator BrickScale(Collider other)
    {
        yield return new WaitForSeconds(0.35f);
        foreach (GameObject brick in bricks)
        {
            brick.GetComponent<Rigidbody>().isKinematic = false;
            brick.GetComponent<Rigidbody>().useGravity = true;
            brick.GetComponent<BoxCollider>().enabled = true;
            brick.GetComponent<Collider>().isTrigger = false;
        }
        gameObject.transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), 5);
        yield return new WaitForSeconds(0.4f);
        gameObject.transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 1);
        foreach (GameObject brick in bricks)
        {
            brick.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator SledgeScale(Transform other)
    {
        yield return new WaitForSeconds(1.1f);
        //other.transform.DOScale(new Vector3(other.transform.localScale.x + 1.25f, other.transform.localScale.y + 0.25f, other.transform.localScale.z + 0.2f), 0.1f).
        //        OnComplete(() => other.transform.DOScale(new Vector3(other.transform.localScale.x - 1f, other.transform.localScale.y - 0.2f, other.transform.localScale.z - 0.1f), 0.1f));
        ////yield return new WaitForSeconds(0.1f);
        //other.transform.DOScale(new Vector3(other.transform.localScale.x + 1.25f, other.transform.localScale.y + 0.25f, other.transform.localScale.z + 0.2f), 0.1f).
        //        OnComplete(() => other.transform.DOScale(new Vector3(other.transform.localScale.x - 1f, other.transform.localScale.y - 0.2f, other.transform.localScale.z - 0.1f), 0.1f));
        //yield return new WaitForSeconds(0.1f);
        //other.transform.DOScale(new Vector3(other.transform.localScale.x + 1.25f, other.transform.localScale.y + 0.25f, other.transform.localScale.z + 0.2f), 0.1f).
        //        OnComplete(() => other.transform.DOScale(new Vector3(other.transform.localScale.x - 1f, other.transform.localScale.y - 0.2f, other.transform.localScale.z - 0.1f), 0.1f));
        //OnComplete(() => other.transform.DOScale(new Vector3(other.transform.localScale.x + 1.25f, other.transform.localScale.y + 0.25f, other.transform.localScale.z + 0.2f), 0.1f)).
        //OnComplete(() => other.transform.DOScale(new Vector3(other.transform.localScale.x - 1f, other.transform.localScale.y - 0.2f, other.transform.localScale.z - 0.1f), 0.1f)).
        //OnComplete(() => other.transform.DOScale(new Vector3(other.transform.localScale.x + 1.25f, other.transform.localScale.y + 0.25f, other.transform.localScale.z + 0.2f), 0.1f).
        //OnComplete(() => other.transform.DOScale(new Vector3(other.transform.localScale.x - 1f, other.transform.localScale.y - 0.2f, other.transform.localScale.z - 0.1f), 0.1f)));

    }

    private void DestrotWall()
    {
        Destroy(gameObject);
    }

    void ScoreTime()
    {
        settings.score--;
    }
}
