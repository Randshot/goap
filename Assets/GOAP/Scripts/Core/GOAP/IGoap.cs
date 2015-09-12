using UnityEngine;
using System.Collections;

/**
 * Collect the world data for this Agent that will be
 * used for GOAP planning.
 */
using System.Collections.Generic;


/**
 * Any agent that wants to use GOAP must implement
 * this interface. It provides information to the GOAP
 * planner so it can plan what actions to use.
 * 
 * It also provides an interface for the planner to give 
 * feedback to the Agent and report success/failure.
 */
public interface IGoap
{
	/**
	 * The starting state of the Agent and the world.
	 * Supply what states are needed for actions to run.
	 */
	HashSet<KeyValuePair<string,object>> getWorldState ();

	/**
	 * Give the planner a new goal so it can figure out 
	 * the actions needed to fulfill it.
	 */
    List<GoapTag> createGoalState();

	/**
	 * No sequence of actions could be found for the supplied goal.
	 * You will need to try another goal
	 */
    void planFailed(List<GoapTag> failedGoal);

	/**
	 * A plan was found for the supplied goal.
	 * These are the actions the Agent will perform, in order.
	 */
	void planFound (GoapTag goal, Queue<GoapAction> actions);

	/**
	 * All actions are complete and the goal was reached. Hooray!
	 */
	void actionsFinished ();

	/**
	 * One of the actions caused the plan to abort.
	 * That action is returned.
	 */
	void planAborted (GoapAction aborter);

	/**
	 * Called during Update. Move the agent towards the target in order
	 * for the next action to be able to perform.
	 * Return true if the Agent is at the target and the next action can perform.
	 * False if it is not there yet.
	 */
	bool moveAgent(GoapAction nextAction);

    void Init();
    void Tick();
    void Release();

    /// <summary>
    /// save agent instance
    /// </summary>
    IAgent Agent { get; set; } 
}

