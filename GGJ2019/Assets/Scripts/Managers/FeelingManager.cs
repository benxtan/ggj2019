using UnityEngine;

public class FeelingManager : MonoBehaviour
{
    public enum FeelingType
    {
        Beer,
        Fish,
        Love,
        Game,
        Gym,
        Sleep,
        Bath
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Feeling GetRandomFeeling()
    {
        Feeling feeling = new Feeling();

        var values = System.Enum.GetValues(typeof(FeelingType));
        feeling.feelingType = (FeelingType)Random.Range(0, values.Length);

        return feeling;
    }
}
