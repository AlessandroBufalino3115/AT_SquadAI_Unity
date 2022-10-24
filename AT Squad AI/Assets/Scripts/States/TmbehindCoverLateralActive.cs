using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmbehindCoverLateralActive : TeamMateBaseState
{


    private bool showing;

    private float showingCooldown;
    private float showingTimer;

    private float notShowingCooldown;
    private float notShowingTimer;

    List<GameObject> list = new List<GameObject>() ;

    //literally does nothing, they just spawned they just look around, still have some enemy check but overall do nothing
    // also we need to have propriaterys timers here one for the cooldown and one for the reantry
    public override void EnterState(TeamMateStateManager teamMate)
    {
        showing = false;
        Debug.Log(teamMate.transform.name + " is in the lateral activate state ");


        showingCooldown = 3f; //set the timer for how long the obj is going to be showing
        notShowingCooldown = 1f;


        ShowSelf(teamMate);
    }

    public override void OnUpdate(TeamMateStateManager teamMate)
    {
        if (showing)
        {
            showingTimer += Time.deltaTime;

            if (showingTimer >= showingCooldown)
            {
                showingTimer = 0;
                showing = !showing;
                ShowSelf(teamMate);
            }
        }
        else
        {
            notShowingTimer += Time.deltaTime;

            if (notShowingTimer >= notShowingCooldown)
            {
                notShowingTimer = 0;
                showing = !showing;
                ShowSelf(teamMate);
            }
        }
    }




    // is where we see if there are any enemies left
    public void ShowSelf(TeamMateStateManager teamMate)
    {
        if (showing)
        {

            teamMate.transform.GetComponent<MeshRenderer>().material.color = Color.blue;

            if ( teamMate.currCoverType == TeamMateStateManager.CoverType.NEGATIVE)
            {
            }
            else if (teamMate.currCoverType == TeamMateStateManager.CoverType.POSITIVE) 
            {
            }

            list = CheckForEnemiesAround(teamMate);
            if (list.Count > 0)
            {
                teamMate.ChangeState(4);
            }
        }
        else
        {

            teamMate.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            //hide
        }
    }

  

}