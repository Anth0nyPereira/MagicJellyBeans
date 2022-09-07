
public class StoredData
{
    private CharacterData cData;
    private FloatSO stressLevelSO;
    private FloatSO barPosition;

    public StoredData(CharacterData cData, FloatSO stressLevelSO, FloatSO barPosition)
    {
        this.cData = cData;
        this.stressLevelSO = stressLevelSO;
        this.barPosition = barPosition;
    }
}
