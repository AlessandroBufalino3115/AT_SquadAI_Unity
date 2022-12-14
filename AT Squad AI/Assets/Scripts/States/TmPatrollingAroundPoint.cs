using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TmPatrollingAroundPoint : TeamMateBaseState
{
     // given a point, choose a random position around that point dont fuck with buildings
    public override void EnterState(TeamMateStateManager teamMate)
    {

        UIManager.instance.SetIcon(1, teamMate.memberName);
        teamMate.currStateText = "PATROLLING AROUND P";
        Debug.Log(teamMate.transform.name + " is in the patrol around state ");
    }

    public override void OnUpdate(TeamMateStateManager teamMate)
    {

        var list = CheckForEnemiesAround(teamMate);


        if (list.Count > 0)
        {
            teamMate.Allerted = true;

            teamMate.NavMeshAgent.isStopped = true;

            ShootAt(list[0], teamMate);

        }
        else 
        {



            teamMate.NavMeshAgent.isStopped = false;
            teamMate.Allerted = false;
        }




        GoToPoint(teamMate.PatrolPoint,teamMate);



        if (ReachedDestination(teamMate)) 
        {
            Debug.Log($"dffdssfdfds");
            Vector3 newPos = new Vector3(teamMate.PatrolPoint.x + Random.Range(-7,7) , teamMate.transform.position.y, teamMate.PatrolPoint.z + Random.Range(-7, 7));
            teamMate.PatrolPoint = newPos;
            GoToPoint(newPos, teamMate);
        }
    }



    public override void OnExit(TeamMateStateManager teamMate)
    {

    }


}
//new TmDead(),
//new TmFindCover(),
//new TmGoToCover(),
//new TmIdleWaiting(),
//new TmInCoverFight(),
//new TmInCoverIdle(),
//new TmInFormationFight(),
//new TmInFormationIdle(),
//new TmPatrollingAroundPoint(),
//new TmUseAbility()