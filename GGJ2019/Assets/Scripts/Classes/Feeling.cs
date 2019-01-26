using UnityEngine;
using static FeelingManager;

public class Feeling
{
    public FeelingType feelingType;

    public override string ToString()
    {
        return System.Enum.GetName(typeof(FeelingType), feelingType);
    }
}
