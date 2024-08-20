using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRailgun : MonoBehaviour
{
    public GameObject IceRail;
    void Start()
    {
        IceRail = this.transform.GetChild(0).gameObject;
    }
    // Start is called before the first frame update
    public void ActivateAttack()
    {
        IceRail.SetActive(true);
        StartCoroutine(DeactivateAttack());
    }

    public IEnumerator DeactivateAttack()
    {
        yield return new WaitForSeconds(IceRail.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        IceRail.SetActive(false);
    }
}
