using UnityEngine;
using LibCSNStandard;
using System.Collections;

public class GameDBF : MonoBehaviour
{
	private static DBFData m_DBF = new DBFData();

	void Awake()
	{
        Add<DBFEquip>(GameDefine.szDBFEquip);
        Add<DBFFeature>(GameDefine.szDBFFeature);
        Add<DBFLanguage>(GameDefine.szDBFLanguage);
        Add<DBFMonster>(GameDefine.szDBFMonster);
		Add<DBFAchievement>(GameDefine.szDBFAchievement);
		Add<DBFReward>(GameDefine.szDBFReward);
	}

    public static void Add<T>(string szDBFName) where T : DBF
	{
		Debug.Log("load dbf " + szDBFName + " " + (m_DBF.Add<T>(szDBFName, "DBF/" + szDBFName) ? "success" : "failed"));
	}
    public static DBF GetEquip(Argu GUID)
	{
		return m_DBF.Get(GameDefine.szDBFEquip, GUID);
	}
    public static DBFItor GetEquip()
	{
		return m_DBF.Get(GameDefine.szDBFEquip);
	}
    public static DBF GetFeature(Argu GUID)
	{
		return m_DBF.Get(GameDefine.szDBFFeature, GUID);
	}
    public static DBFItor GetFeature()
	{
		return m_DBF.Get(GameDefine.szDBFFeature);
	}
	public static string GetLanguage(Argu GUID)
	{
		DBFLanguage Data = m_DBF.Get(GameDefine.szDBFLanguage, GUID) as DBFLanguage;

		if(Data == null)
			return "";

		switch(DataGame.pthis.Language)
		{
		case ENUM_Language.zhTW: return Data.zhTW;
		case ENUM_Language.enUS: return Data.enUS;
		default: return "";
		}//switch
	}
    public static DBFItor GetLanguage()
	{
		return m_DBF.Get(GameDefine.szDBFLanguage);
	}
    public static DBF GetMonster(Argu GUID)
	{
		return m_DBF.Get(GameDefine.szDBFMonster, GUID);
	}
    public static DBFItor GetMonster()
	{
		return m_DBF.Get(GameDefine.szDBFMonster);
	}
    public static DBF GetAchievement(Argu GUID)
	{
		return m_DBF.Get(GameDefine.szDBFAchievement, GUID);
	}
    public static DBF GetAchievement(ENUM_Achievement emAchievement)
	{
		return m_DBF.Get(GameDefine.szDBFAchievement, (int)emAchievement);
	}
    public static DBFItor GetAchievement()
	{
		return m_DBF.Get(GameDefine.szDBFAchievement);
	}
    public static DBF GetReward(Argu GUID)
	{
		return m_DBF.Get(GameDefine.szDBFReward, GUID);
	}
    public static DBFItor GetReward()
	{
		return m_DBF.Get(GameDefine.szDBFReward);
	}
}
