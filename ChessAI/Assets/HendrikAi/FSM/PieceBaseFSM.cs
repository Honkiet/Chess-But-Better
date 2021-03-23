using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PieceBaseFSM : StateMachineBehaviour
{
    //reference to  own Piece and others
    public BaseAi baseAi;
    public List<Transform> otherUnits;

    //stats etc
    public Piece piece;
    public NavMeshAgent agent;
    // Start is called before the first frame update

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        baseAi = animator.gameObject.GetComponent<BaseAi>();
        otherUnits = baseAi.GetUnitsList();
        piece = animator.gameObject.GetComponent<Piece>();
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        otherUnits = baseAi.GetUnitsList();
    }

}
