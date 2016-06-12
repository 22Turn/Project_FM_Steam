using UnityEngine;
using System.Collections;

public class Lb_Feature : MonoBehaviour 
{
    public UILabel pLb = null;
    public UISprite pSBg = null;

    public void SetFeature(int iFeature)
    {
        // 顯示取得的特性.
        DBFFeature pDBFFeature = GameDBF.GetFeature(iFeature) as DBFFeature;

		pLb.text = GameDBF.GetLanguage(pDBFFeature.StrID);
        pSBg.width = pLb.width + 12;
        pSBg.height = pLb.height + 5;        
    }
}
