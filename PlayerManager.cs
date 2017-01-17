using Assets;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject player;
    public SpellManager spellManager;
    public Assets.Interface.GUImanager guiManager;
    private GameObject area;
    private float castTime;
    private float actualTime;
    private bool casting;
    private bool enhancing;
    private KeyCode actualKey = KeyCode.Caret;

    //network
    public PhotonView photonView;


    void Update()
    {
        if (!casting && !enhancing)
            casting = IsCasting();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelCast();
        }
        if (casting)
        {
            actualTime += Time.deltaTime;
            if (actualTime >= castTime)
            {
                casting = false;
                enhancing = true;
                //enhance works like casting
                castTime = spellManager.GetEnhanceTime(actualKey);
                actualTime = 0;
                spellManager.SetTimer(actualKey);
            }
        }
        else if (enhancing)
        {
            actualTime += Time.deltaTime;
            //he is enhancing, so he can click whenever he wants
            if (area == null)
            {
                area = (GameObject)Instantiate(Resources.Load("Prefabs/Characters/Spells/Casts/Area"));
            }
            if (actualTime > castTime)
            {
                actualTime = 0;
                castTime = 0;
                enhancing = false;

                //break the spell
                spellManager.Cancel(actualTime <= castTime);
                CancelCast();
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit, 1000))
                    {
                        Vector3 target = Input.mousePosition;
                        target.x = hit.point.x;
                        target.y = hit.point.y + 0.1f;
                        target.z = hit.point.z;

                        actualTime = 0;
                        castTime = 0;
                        spellManager.Start(player.transform.position, target, actualKey);
                        CancelCast();
                        ClickToMove.SwitchMove(true);
                    }
                }
            }

        }
    }
    private void CancelCast()
    {
        if (area != null)
        {
            Destroy(area);
            area = null;
        }
        ClickToMove.SwitchMove(true);
        spellManager.Cancel(actualTime <= castTime);

    }
    private bool IsCasting()
    {
        actualKey = KeyCode.Caret;
        if (Input.GetKeyDown(KeyCode.Q))
            actualKey = KeyCode.Q;
        if (Input.GetKeyDown(KeyCode.W))
            actualKey = KeyCode.W;
        if (Input.GetKeyDown(KeyCode.E))
            actualKey = KeyCode.E;
        if (Input.GetKeyDown(KeyCode.R))
            actualKey = KeyCode.R;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            actualKey = KeyCode.Alpha1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            actualKey = KeyCode.Alpha2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            actualKey = KeyCode.Alpha3;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            actualKey = KeyCode.Alpha4;

        casting = actualKey != KeyCode.Caret;
        if (casting)
        {
            bool canCast = spellManager.CanCast(actualKey);
            //If it starts to cast, set the cast time.
            if (castTime == 0 && canCast)
            {
                ClickToMove.StopMove();
                ClickToMove.SwitchMove(false);
                castTime = spellManager.GetCastTime(actualKey);
                actualTime = 0;
                spellManager.StartCastBar(actualKey, Time.deltaTime / 2);
            }
            else
                casting = false;
        }


        return casting;
    }
}
