using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public enum State {
        GENERATOR_ROOM_UNLOCKED,
        GENERATOR_RUNNING,
        COMPUTER_AUTHORIZED,
        LOCKER_OPEN,
        USB_IN_COMPUTER,
        COMPUTER_FULL_ACCESS,
        HAS_POWER_CELL,
    }

    private static HashSet<State> states = new HashSet<State>();

    public static bool IsState(State state) {
        return states.Contains(state);
    }

    public static void SetState(State state) {
        states.Add(state);
    }

    public static void ClearState(State state) {
        states.Remove(state);
    }

    internal static void SetState(object lOCKER_OPEN)
    {
        throw new NotImplementedException();
    }
}
