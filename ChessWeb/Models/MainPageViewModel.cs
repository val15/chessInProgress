﻿using Chess2Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessWeb.Models
{
  public class MainPageViewModel
  {
    public bool IsFormLoander  { get; set; } = false;

    public  string FromGridIndex { get; set; }

    public  string ToGridIndex { get; set; }
    public Board MainBord { get; set; }

    public string[] Cases { get; set; }

    public List<Pawn> PawnCases { get; set; }

    public string RevertWrapperClass { get; set; }
    public List<string> MovingList { get; set; }

    public string WhiteScore { get; set; }

    public string BlackScore { get; set; }

    public List<string> HuntingBoardWhiteImageList { get; set; }
    public List<string> HuntingBoardBlackImageList { get; set; }



    public Pawn GetPawn(int index)
    {
      return PawnCases[index];
    }


    public void Refresh(Board board)
    {
      PawnCases = new List<Pawn>();
      MainBord = board;
      Cases = MainBord.GetCases();
      var index = 0;

      foreach (var caseContain in Cases)
      {
        var imageIsExist = false;
        var pawnName = "";
        var pawnColor = "";
        if (caseContain.Contains("|"))
        {
          imageIsExist = true;
          var datas = caseContain.Split('|');
          pawnName = datas[0];
          pawnColor = datas[1];
          if (pawnName == "B")
          {
            pawnName = "Bishop";

          }
          if (pawnName == "K")
          {
            pawnName = "King";
          }
          if (pawnName == "Q")
          {
            pawnName = "Queen";
          }
          if (pawnName == "T")
          {
            pawnName = "Rook";
          }
          if (pawnName == "C")
          {
            pawnName = "Knight";
          }
          if (pawnName == "P")
          {
            pawnName = "SimplePawn";
          }




          if (pawnColor == "B")
          {
            pawnColor = "Black";
          }
          else
          {

            pawnColor = "White";
          }
        }
        //  / BishopBlack.png
        var pawnImageSrc = $"../../Images00/{pawnName}{pawnColor}.png";

        var shortcolor = "";
        if (!String.IsNullOrEmpty(pawnColor))
          shortcolor = pawnColor[0].ToString();
        Pawn pawn = new Pawn(index, pawnImageSrc, imageIsExist, shortcolor);
        PawnCases.Add(pawn);
        index++;
      }

    }

    public MainPageViewModel(Board board)
    {
      PawnCases = new List<Pawn>();
      MainBord = board;
      Cases = MainBord.GetCases();
      var index = 0;

      foreach (var caseContain in Cases)
      {
        var imageIsExist = false;
        var pawnName = "";
        var pawnColor = "";
        if (caseContain.Contains("|"))
        {
          imageIsExist = true;
          var datas = caseContain.Split('|');
          pawnName = datas[0];
          pawnColor = datas[1];
          if (pawnName == "B")
          {
            pawnName = "Bishop";

          }
          if (pawnName == "K")
          {
            pawnName = "King";
          }
          if (pawnName == "Q")
          {
            pawnName = "Queen";
          }
          if (pawnName == "T")
          {
            pawnName = "Rook";
          }
          if (pawnName == "C")
          {
            pawnName = "Knight";
          }
          if (pawnName == "P")
          {
            pawnName = "SimplePawn";
          }




          if (pawnColor == "B")
          {
            pawnColor = "Black";
          }
          else
          {

            pawnColor = "White";
          }
        }
        //  / BishopBlack.png
        var pawnImageSrc = $"../../Images/{pawnName}{pawnColor}.png";
        var shortcolor = "";
        if (!String.IsNullOrEmpty(pawnColor))
          shortcolor = pawnColor[0].ToString();
        Pawn pawn = new Pawn(index, pawnImageSrc, imageIsExist, shortcolor);
        PawnCases.Add(pawn);
        index++;
      }


    }
  }
}