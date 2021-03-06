﻿using UnityEngine;
using System.Collections;

public class Btn_GetHeavyAmmo : MonoBehaviour 
{
	public int iItemID = 0;
	
	public SpriteRenderer pSprite;
	public UILabel pLbCount;
	// ------------------------------------------------------------------
	void OnPress(bool bIsPress)
	{
		if (bIsPress)
		{
			GetComponent<BoxCollider2D>().enabled = false;
			NGUITools.PlaySound(Resources.Load("Sound/FX/GetItem") as AudioClip);
			// 變更為不受光.
			pSprite.material = UITool.pthis.M_Sprite;
			pSprite.sortingLayerName = "Top";
			// 取得數量.
			pLbCount.text = "+" + DataPickup.pthis.Data[iItemID].iCount;
			GetComponent<Animator>().Play("GetItem");
			// 飛行至定位.
			StartCoroutine(FlyToPos());
		}        
	}
	// ------------------------------------------------------------------
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Look")
			GetComponent<Animator>().Play("TalkShing");
	}
	// ------------------------------------------------------------------
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Look")
			GetComponent<Animator>().Play("Wait");
	}
	// ------------------------------------------------------------------
	IEnumerator FlyToPos()
	{
		int iCount = 1;
		float fFrame = 1;
		
		while (iCount <= 9)
		{
			pSprite.transform.Rotate(0, 0, -10);
			pSprite.transform.localScale = new Vector3(pSprite.transform.localScale.x + (0.01f * iCount), pSprite.transform.localScale.y + (0.01f * iCount), 1);
			iCount++;
			yield return new WaitForEndOfFrame();
		}
		
		yield return new WaitForSeconds(0.8f);

		while (Vector2.Distance(pSprite.transform.position, P_UI.pthis.ObjAmmoHeavy.transform.position) > 0.03f)
		{
			yield return new WaitForEndOfFrame();
			ToolKit.MoveTo(gameObject, P_UI.pthis.ObjAmmoHeavy.transform.position - pSprite.transform.position, 0.8f * fFrame);
			fFrame += 0.05f;
		}
		
		DataPickup.pthis.Data[iItemID].bPickup = true;
		Rule.HeavyAmmoAdd(DataPickup.pthis.Data[iItemID].iCount);
		P_UI.pthis.UpdateResource();

        SysAchieve.pthis.Add(ENUM_Achievement.Total_HeavyAmmo, DataPickup.pthis.Data[iItemID].iCount);
		GoogleAnalyticsV3.getInstance().LogEvent("Count", "Pickup HeavyAmmo", "", 0);       
		
		Destroy(gameObject);
	}
}
