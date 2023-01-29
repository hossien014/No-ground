using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Abed.Utils;
using UnityEngine;

public class consumptionManeger : MonoBehaviour
{

      [SerializeField] consumption[] consumptions = new consumption[3];
      [SerializeField] Coroutine[] Co_Ro = new Coroutine[3];
      [SerializeField] GeneralGUI gu;
      private void Start() { for (int i = 0; i <= 2; i++) consumptions[i] = consumption.Empty; }
      private void LateUpdate() { for (int i = 0; i <= 2; i++) gu.S[i] = consumptions[i].ToString(); }
      public void Consum(Action ItemEffect, Action Neturailer, int LifeTime, consumption consumption)
      {
            int FristEmpty = -1;
            bool Overwrite = false;
            bool EmptySpace = false;
            for (int i = 0; i < 2; i++)
            {
                  if (consumptions[i] == consumption.Empty && FristEmpty == -1) { FristEmpty = i; EmptySpace = true; }
                  if (consumptions[i] == consumption)
                  {     // override Item in Existin one 
                        Overwrite = true;
                        StopCoroutine(Co_Ro[i]); Co_Ro[i] = null;
                        consumptions[i] = consumption;
                        ItemEffect();
                        Co_Ro[i] = StartCoroutine(Neturaliz(Neturailer, LifeTime, i));
                        break;
                  }
            }
            if (Overwrite == false && EmptySpace == true)
            {     // add item in Empty Space 
                  consumptions[FristEmpty] = consumption;
                  ItemEffect();
                  Co_Ro[FristEmpty] = StartCoroutine(Neturaliz(Neturailer, LifeTime, FristEmpty));
            }
            else
            {
                  // override whit oldest Item
                  StopCoroutine(Co_Ro[0]);
                  Co_Ro[0] = null;
                  consumptions[0] = consumption;
                  ItemEffect();
                  Co_Ro[0] = StartCoroutine(Neturaliz(Neturailer, LifeTime, 0));
            }
      }
      IEnumerator Neturaliz(Action Neturailer, float time, int Index)
      {
            yield return new WaitForSeconds(time);
            Co_Ro[Index] = null;
            consumptions[Index] = consumption.Empty;
            Debug.Log("Elapes");
            Neturailer();
      }




}
