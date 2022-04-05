using Chess.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess.Utils
{
  public class Pawn
  {



    public MainWindow MainWindowParent { get; set; }

    public string Name { get; set; }

    private string _location;


    
    public string Location
    {
      get => _location;
      set
      {

        _location = value;
        X = Location[0].ToString();
        Y = Location[1].ToString();

      }
    }


    public string X { get; set; } //a-h

    public string Y { get; set; }//1-8


    public List<string> PossibleTrips { get; set; } //Les déplacement possible: liste des positions possible
    public List<int> PossibleTripsScore { get; set; }

    public string Image { get; set; }
    public string Colore { get; set; }
    public Button AssociateButton { get; set; }

    public Boolean IsSelected { get; set; }

    private DockPanel _dockPanel;
    private Image _image;
    public bool IsFirstMove { get; set; }

    public int Value { get; set; }

    //roc
    public bool IsFirstMoveKing { get; set; }

    public bool IsLeftRookFirstMove { get; set; }
    public bool IsRightRookFirstMove { get; set; }
    public string MinPosition { get; set; }
    public string MaxPosition { get; set; }
    public string BestPositionAfterEmul { get; set; }

    public int MinScore { get; set; }
    public int MaxScore { get; set; }

    public bool IsMaced { get; set; }
    public long ID { get; set; }
    public Pawn()
    {

    }
    public void Clean()
    {
      _dockPanel = new DockPanel();
      /* _dockPanel.Background = Brushes.DarkCyan;
       if (Colore == "White")
         _dockPanel.Background = Brushes.White;*/

      var label = new Label();
      label.Content = Chess2Utils.GetIndexFromLocation(_location);
      _dockPanel.Children.Add(label);
      AssociateButton.Content = _dockPanel;
    }

    /*tsiry;12-08-2021
* Attribution d'un score à une position*/
public bool Compare(Pawn pawnIn)
{

      if (this.Colore != pawnIn.Colore)
        return false;
      if (this.Location != pawnIn.Location)
        return false;
      if (this.Name != pawnIn.Name)
        return false;


      return true;

}



    /*tsiry;12-08-2021
* Attribution d'un score à une position
*pour generer le symetrie du pawn actuel
*/
    public Pawn GetSymmetry()
    {
      var symmetryPawn = new Pawn(this.Name, this.Location, new Button(), this.Colore, this.MainWindowParent);
      symmetryPawn.IsFirstMove = this.IsFirstMove;
      symmetryPawn.IsFirstMoveKing = this.IsFirstMoveKing;
      symmetryPawn.IsLeftRookFirstMove = this.IsLeftRookFirstMove;
      symmetryPawn.IsRightRookFirstMove = this.IsRightRookFirstMove;
      var yInt = Int32.Parse(symmetryPawn.Location[1].ToString());
      if (symmetryPawn.Colore == "White")
        symmetryPawn.Colore = "Black";
        
      else
        symmetryPawn.Colore = "White";

      yInt = (8 - yInt) + 1;



      /* if (symmetryPawn.Colore == "Black")
         yInt = (8 - yInt) + 1;


       if (symmetryPawn.Colore == "White")
         yInt = 8 - (8 - yInt) + 1;*/

      symmetryPawn.Y = yInt.ToString();
      symmetryPawn.Location = symmetryPawn.X + symmetryPawn.Y;

      return symmetryPawn;

    }

    public Pawn(string name, string location, Button associateButton, string colore, MainWindow mainWindowParent)
{

  ID = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

  MainWindowParent = mainWindowParent;
  Name = name;


  SetValue();






  if (Name == "SimplePawn")
    IsFirstMove = true;
  if (Name == "King")
  {
    IsFirstMoveKing = true;
    IsLeftRookFirstMove = true;
    IsRightRookFirstMove = true;
  }


  Colore = colore;
  Location = location;
  X = Location[0].ToString();
  Y = Location[1].ToString();
  PossibleTrips = new List<string>();
  PossibleTripsScore = new List<int>();
  AssociateButton = associateButton;
  if (AssociateButton == null)
    return;
  _dockPanel = new DockPanel();
  _image = new Image();
  _image.Height = 60;
  _image.Width = 60;
  /*
  _dockPanel.Background = Brushes.DarkCyan;
  if (Colore== "White")
    _dockPanel.Background = Brushes.White;*/


    _image.Source = new BitmapImage(new Uri(@"/Images/" + Name + Colore + ".png", UriKind.Relative));
     
      _dockPanel.Children.Add(_image);

      var label = new Label();
      label.Content = Chess2Utils.GetIndexFromLocation(_location);
      _dockPanel.Children.Add(label);

      AssociateButton.Content = _dockPanel;




    }

    public void SetValue()
    {
      switch (Name)
      {
        case "SimplePawn":
          Value = 1;
          break;
        case "Queen":
          Value = 9;
          break;
        case "Rook":
          Value = 5;
          break;
        case "Bishop":
          Value = 3;
          break;
        case "Knight":
          Value = 3;
          break;
        case "King":
          Value = 100;
          break;
      }
    }



    public void FillPossibleTrips(List<Pawn> currentPawnList = null)
    {
      // TempsPawnList = null;

      PossibleTrips.Clear();
      if (this.Name == "SimplePawn")
        fillPossibleTripsSimplePawn(this.Colore, currentPawnList);
      if (this.Name == "Knight")
        fillPossibleTripsKnight(currentPawnList);
      if (this.Name == "Rook")
        fillPossibleTripsRook(currentPawnList);
      if (this.Name == "Bishop")
        fillPossibleTripsBishop(currentPawnList);
      if (this.Name == "Queen")
        fillPossibleTripsQueen(currentPawnList);//King
      if (this.Name == "King")
        fillPossibleTripsKing(currentPawnList);

      //EvaluateScorePossibleTrips();

      IsMaced = FindIsMaced();

    }

    public void FillPossibleTripsWhitheCurrentPawnList(List<Pawn> currentPawnList)
    {
      // TempsPawnList = null;

      PossibleTrips.Clear();
      if (this.Name == "SimplePawn")
        fillPossibleTripsSimplePawn(this.Colore, currentPawnList);
      if (this.Name == "Knight")
        fillPossibleTripsKnight(currentPawnList);
      if (this.Name == "Rook")
        fillPossibleTripsRook(currentPawnList);
      if (this.Name == "Bishop")
        fillPossibleTripsBishop(currentPawnList);
      if (this.Name == "Queen")
        fillPossibleTripsQueen(currentPawnList);//King
      if (this.Name == "King")
        fillPossibleTripsKing(currentPawnList);

      //EvaluateScorePossibleTrips();

      IsMaced = FindIsMaced();

    }

    public bool FindIsMaced()
    {
      var result = false;
      foreach (var pawn in MainWindowParent.GetOpignonPawnList(Colore))
      {
        //TODO pour les pions on ne prend pas les PossibleTrips mais les diagonaux avant
        if (pawn.PossibleTrips.Contains(Location))
        {
          result = true;
          break;
        }
      }
      return result;
    }
    public bool FindIsMaced(List<Pawn> currentPawnList)
    {
      var result = false;
      foreach (var pawn in currentPawnList.Where(x => x.Colore != Colore))
      {
        pawn.FillPossibleTrips();
        if (pawn.PossibleTrips.Contains(Location))
        {
          result = true;
          break;
        }
      }
      return result;
    }


    public int EvaluateScore()
    {
      var score = 0;
      var pawn = MainWindowParent.GetPawn(this.Location);
      if (pawn == null)
      {
        score = 0;
      }
      else
      {


        if (pawn.Colore != this.Colore)
        {
          score += pawn.Value;
        }

      }
      /* var opignonList = MainWindowParent.GetOpignonPawnList(this.Colore);
       foreach (var opignonPawn in opignonList)
       {
         if (opignonPawn.PossibleTrips.Contains(this.Location))
         {
           score += -1;
         }
       }*/
      return score;
    }

    public void EvaluateScorePossibleTrips()//liste des position possibles avec leurs score respective
    {
      PossibleTripsScore.Clear();
      foreach (var position in PossibleTrips)
      {
        var score = 0;
        var pawn = MainWindowParent.GetPawn(position);
        if (pawn == null)
        {
          score = 0;
        }
        else
        {
          if (pawn.Colore != this.Colore)
          {
            score += pawn.Value;
          }

        }
        var opignonList = MainWindowParent.GetOpignonPawnList(this.Colore);
        foreach (var opignonPawn in opignonList)
        {
          if (opignonPawn.PossibleTrips.Contains(position))
          {
            score += -1;
          }
        }

        /* if(this.Name=="King")
         {
           if(opignonList.PossibleTrips.Contains(this.Location))

           foreach (var opignonPawn in opignonList)
           {
             if (!opignonPawn.PossibleTrips.Contains(position))
             {
               score += 50;
             }
           }
         }*/




        var possibleCase = MainWindowParent.GetCase(position);
        if (possibleCase != null)
          possibleCase.Score = score;

        PossibleTripsScore.Add(score);
      }
    }

    public void EmulateAllPossibleTips()
    {
      /*List<Pawn> lst = new List<Pawn>();
      lst.AddRange(MainWindowParent.PawnList);*/
      var tupleList = new List<(string, int, string, int, string)>();
      List<string> lst = new List<string>();
      lst.AddRange(this.PossibleTrips);
      //this.PossibleTrips();

      for (int i = 0; i < lst.Count; i++)
      {
        var d = lst[i];


        /* if ( d== "d7")
         {
           var t = lst[i];
         }*/


        tupleList.Add(MainWindowParent.Emulate(this.Location, lst[i], MainWindowParent.PawnList));
      }

      if (tupleList.Count > 0)
      {
        var minItem = tupleList.OrderBy(x => x.Item2).First();
        var maxItem = tupleList.OrderByDescending(x => x.Item4).First();
        //var minPo


        MinPosition = minItem.Item1;
        MaxPosition = maxItem.Item3;
        MinScore = minItem.Item2;
        MaxScore = maxItem.Item4;
        BestPositionAfterEmul = maxItem.Item5;
      }

    }


    /* private AlphaBeta()
     {
       foreach (var pawn in PossibleTrips)
       {

       }
     }*/




    private void fillPossibleTripsSimplePawn(string colore, List<Pawn> currentPawnList = null)
    {
      var toAdd = 0;
      if (Colore == "White")
      {
        toAdd = +1;

      }
      else
      {
        toAdd = -1;
      }

      var xasciiCode = (int)Convert.ToChar(X);
      var intY = 0;
      //Int32.Parse(Y);
      bool success = Int32.TryParse(Y, out intY);
      if (!success)
        return;

      var tripsPosition = X + (intY + (toAdd)).ToString();
      var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (pawnInTrips == null)
      {
        PossibleTrips.Add(tripsPosition);
      }
      if (IsFirstMove)
      {
        tripsPosition = X + (intY + (toAdd)).ToString();
        pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (pawnInTrips == null)
        {
          tripsPosition = X + (intY + (toAdd) + (toAdd)).ToString();
          pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
          if (pawnInTrips == null)
          {
            PossibleTrips.Add(tripsPosition);
          }
        }


      }

      //pour les attaques des pions
      tripsPosition = Convert.ToChar(xasciiCode - 1).ToString() + (intY + toAdd).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (pawnInTrips != null)
      {
        if (pawnInTrips.Colore != this.Colore)
          PossibleTrips.Add(tripsPosition);
      }
      tripsPosition = Convert.ToChar(xasciiCode + 1).ToString() + (intY + toAdd).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (pawnInTrips != null)
      {
        if (pawnInTrips.Colore != this.Colore)
          PossibleTrips.Add(tripsPosition);
      }








    }
    private void fillPossibleTripsKnight(List<Pawn> currentPawnList = null)
    {
      var avalablesPositionList = new List<string>();


      var xasciiCode = (int)Convert.ToChar(X);
      var intY = Int32.Parse(Y);


      var tripsPosition = Convert.ToChar(xasciiCode - 1).ToString() + (intY + 2).ToString();
      var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }



      tripsPosition = Convert.ToChar(xasciiCode + 1).ToString() + (intY + 2).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }


      tripsPosition = Convert.ToChar(xasciiCode + 2).ToString() + (intY - 1).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }


      tripsPosition = Convert.ToChar(xasciiCode + 2).ToString() + (intY + 1).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }

      tripsPosition = Convert.ToChar(xasciiCode - 1).ToString() + (intY - 2).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }

      tripsPosition = Convert.ToChar(xasciiCode + 1).ToString() + (intY - 2).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }

      tripsPosition = Convert.ToChar(xasciiCode - 2).ToString() + (intY - 1).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }

      tripsPosition = Convert.ToChar(xasciiCode - 2).ToString() + (intY + 1).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }

      PossibleTrips.AddRange(avalablesPositionList);

    }

    private void fillPossibleTripsRook(List<Pawn> currentPawnList = null)
    {
      var avalablesPositionList = new List<string>();

      var intY = Int32.Parse(Y);
      for (int i = intY + 1; i <= 8; i++)
      {
        var tripsPosition = (X) + i.ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }
      for (int i = intY - 1; i > 0; i--)
      {
        var tripsPosition = (X) + i.ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }


      var xasciiCode = (int)Convert.ToChar(X);
      for (int i = 1; i <= 97 + 8 && xasciiCode < 104; i++)
      {
        var tripsPosition = (Convert.ToChar(xasciiCode + i)).ToString() + Y;
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }
      for (int i = xasciiCode - 1; i >= 97; i--)
      {
        var tripsPosition = (Convert.ToChar(i)).ToString() + Y;
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }


      PossibleTrips.AddRange(avalablesPositionList);
    }
    private void fillPossibleTripsBishop(List<Pawn> currentPawnList = null)
    {
      var avalablesPositionList = new List<string>();
      var xasciiCode = (int)Convert.ToChar(X);
      var intY = Int32.Parse(Y);

      for (int i = xasciiCode + 1, j = intY; i < 97 + 8 && j < 8; i++, j++)
      {
        var tripsPosition = Convert.ToChar(i).ToString() + (j + 1).ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }
      for (int i = xasciiCode, j = intY; i > 97 && j > 1; i--, j--)
      {
        var tripsPosition = (Convert.ToChar(i - 1)).ToString() + (j - 1).ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }

      for (int i = xasciiCode - 1, j = intY; i >= 97 && j <= 8; i--, j++)
      {
        var tripsPosition = (Convert.ToChar(i)).ToString() + (j + 1).ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }

      for (int i = xasciiCode, j = intY; i < 97 + 7 && j > 1; i++, j--)
      {
        var tripsPosition = Convert.ToChar(i + 1).ToString() + (j - 1).ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }

      /* if(this.Colore == "White" && this.Location == "c1" && (avalablesPositionList.Contains("g5")))
       {
         var debugText = "INITIAL POSITION: " + X + Y + "\n";

         foreach (var position in avalablesPositionList)
         {
           debugText += position + "\n";
         }

         MainWindowParent.SetDebugTextBlockText(debugText);
       }
       */

      PossibleTrips.AddRange(avalablesPositionList);
    }


    private void fillPossibleTripsQueen(List<Pawn> currentPawnList = null)
    {
      var avalablesPositionList = new List<string>();
      var xasciiCode = (int)Convert.ToChar(X);
      var intY = Int32.Parse(Y);

      for (int i = intY + 1; i <= 8; i++)
      {
        var tripsPosition = (X) + i.ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }
      for (int i = intY - 1; i > 0; i--)
      {
        var tripsPosition = (X) + i.ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }
      for (int i = 1; i <= 97 + 8 && xasciiCode < 104; i++)
      {
        var tripsPosition = (Convert.ToChar(xasciiCode + i)).ToString() + Y;
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }
      for (int i = xasciiCode - 1; i >= 97; i--)
      {
        var tripsPosition = (Convert.ToChar(i)).ToString() + Y;
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }



      for (int i = xasciiCode + 1, j = intY; i < 97 + 8 && j < 8; i++, j++)
      {
        var tripsPosition = Convert.ToChar(i).ToString() + (j + 1).ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }
      for (int i = xasciiCode, j = intY; i > 97 && j > 1; i--, j--)
      {
        var tripsPosition = (Convert.ToChar(i - 1)).ToString() + (j - 1).ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }

      for (int i = xasciiCode - 1, j = intY; i >= 97 && j <= 8; i--, j++)
      {
        var tripsPosition = (Convert.ToChar(i)).ToString() + (j + 1).ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }

      for (int i = xasciiCode, j = intY; i < 97 + 7 && j > 1; i++, j--)
      {
        var tripsPosition = Convert.ToChar(i + 1).ToString() + (j - 1).ToString();
        var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (MainWindowParent.GetCase(tripsPosition) == null)
          break;
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
          continue;
        }
        if (pawnInTrips.Colore == this.Colore)//pion alier
        {
          break;
        }
        else
        {
          avalablesPositionList.Add(tripsPosition);
          break;
        }
      }




      PossibleTrips.AddRange(avalablesPositionList);
    }

    private void fillPossibleTripsKing(List<Pawn> currentPawnList = null)
    {
      var avalablesPositionList = new List<string>();
      var xasciiCode = (int)Convert.ToChar(X);
      var intY = Int32.Parse(Y);


      var tripsPosition = (X) + (intY + 1).ToString();
      var pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }




      tripsPosition = (X) + (intY - 1).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }




      tripsPosition = (Convert.ToChar(xasciiCode + 1)).ToString() + Y;
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }

      tripsPosition = (Convert.ToChar(xasciiCode - 1)).ToString() + Y;
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }


      tripsPosition = Convert.ToChar(xasciiCode + 1).ToString() + (intY + 1).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }

      tripsPosition = Convert.ToChar(xasciiCode - 1).ToString() + (intY + 1).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }


      tripsPosition = Convert.ToChar(xasciiCode + 1).ToString() + (intY - 1).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }

      tripsPosition = Convert.ToChar(xasciiCode - 1).ToString() + (intY - 1).ToString();
      pawnInTrips = MainWindowParent.GetPawn(tripsPosition, currentPawnList);
      if (MainWindowParent.GetCase(tripsPosition) != null)
      {
        if (pawnInTrips == null)
        {
          avalablesPositionList.Add(tripsPosition);
        }
        else
        {
          if (pawnInTrips.Colore != this.Colore)//pion alier
          {
            avalablesPositionList.Add(tripsPosition);
          }
        }
      }
      var opignonPawnList = MainWindowParent.GetOpignonPawnList(this.Colore);
      //Ajout du roc
      //si le roi ne s'est pas encore deplacer
      if (Name == "King")
      {
        if (IsFirstMoveKing)//si le roi n'a pas bouger
        {
          if (IsLeftRookFirstMove)//si le fou n'as pas bouger
          {
            var isFree = true;
            for (int i = 101; i > 98; i--)//si il n'y a rein entre le roi et le fou
            {
              var location = Convert.ToChar(i - 1).ToString() + Y;
              var pawnInposition = MainWindowParent.GetPawn(location);
              if (pawnInposition != null)
              {
                isFree = false;
                break;
              }

              //si en rocant, le rois ne passe pas par une case de déplacement possible de l'adversaire
              //si la case n'est pas cible des pions adverses

              if (opignonPawnList != null)
              {
                foreach (var item in opignonPawnList)
                {
                  if (item.PossibleTrips.Contains(location))
                  {
                    isFree = false;
                    break;
                  }
                }
              }
            }

            //si le roi est sous la menache d'un echec



            if (isFree && !isChess())
            {
              tripsPosition = Convert.ToChar(xasciiCode - 2).ToString() + (intY).ToString();
              avalablesPositionList.Add(tripsPosition);
            }
          }

          if (IsRightRookFirstMove)
          {

            //si il n'y a rien entre la tour et le roi
            var isFree = true;
            for (int i = 1; i < 3; i++)
            {
              var location = Convert.ToChar(xasciiCode + i).ToString() + Y;
              var pawnInposition = MainWindowParent.GetPawn(location);
              //si en rocant, le rois ne passe pas par une case de déplacement possible de l'adversaire
              //si la case n'est pas cible des pions adverses


              foreach (var item in opignonPawnList)
              {
                if (item.PossibleTrips.Contains(location))
                {
                  isFree = false;
                  break;
                }
              }
              if (pawnInposition != null)
              {
                isFree = false;
                break;
              }

            }
            if (isFree && !isChess())
            {
              tripsPosition = Convert.ToChar(xasciiCode + 2).ToString() + (intY).ToString();
              avalablesPositionList.Add(tripsPosition);
            }

          }

        }
      }

      var opignonPawnPosibleTips = new List<string>();
      foreach (var opignonPawn in opignonPawnList)
      {
        if (opignonPawn.Name != "King")
        {
          opignonPawn.FillPossibleTrips();
          opignonPawnPosibleTips.AddRange(opignonPawn.PossibleTrips);
        }

      }

      /*for (int i = 0; i < avalablesPositionList.Count; i++)
      {
        var avalablePosition = avalablesPositionList[i];
        if (opignonPawnPosibleTips.Contains(avalablePosition))
          avalablesPositionList.Remove(avalablePosition);
      }*/




      PossibleTrips.AddRange(avalablesPositionList);

    }

    private bool isChess()
    {
      if (this.Name == "King")
      {
        var opignonPawnList = MainWindowParent.GetOpignonPawnList(this.Colore);
        foreach (var item in opignonPawnList)
        {
          if (item.Location == this.Location)
          {
            return true;
          }
        }
      }
      return false;
    }



    public void ColorAvaleblesCases()
    {
      // var buttonSender = (Button)sender;

      // on reitialise toutes les case
      MainWindowParent.SetDefaultColoreAllCases();
    
      MainWindowParent.SelectedPawn = this;
      foreach (var item in PossibleTrips)
      {
        var avaleblesCases = MainWindowParent.GetCase(item);
        var avalableButton = (Button)MainWindowParent.FindName(item);
        if (avalableButton != null)
        {
          avalableButton.Background = Brushes.Yellow;
          avalableButton.ToolTip = avaleblesCases.Score.ToString();
        }




      }

      //colorer les PossibleTrips
    }

    public void Move(Case newCase)//quan on déplace un pion, en fonction de sa position; 
    {




      if (MainWindowParent.CurrentTurn != this.Colore)
        return;

      /*tsiry;28-05-2021
* creation de l'historique
* on copie les entien coordonnées dans un docier*/
      if (MainWindowParent.CurrentTurn == "Black")
        MainWindowParent.SaveToHistorical(MainWindowParent.BlackTurnNumber, MainWindowParent.CurrentTurn);
      else if (MainWindowParent.CurrentTurn == "White")
        MainWindowParent.SaveToHistorical(MainWindowParent.BlackTurnNumber, MainWindowParent.CurrentTurn);

    //  var t0 = MainWindowParent.PawnList.Count;
      var oldLocation = this.Location;

      //attaque


      //this.Location = newCase.CaseName;

      //this.AssociateButton = newCase.ButtonCase;
      _image = null;
      _image = new Image();
      _image.Height = 60;
      _image.Width = 60;
      _image.Source = new BitmapImage(new Uri(@"/Images/" + Name + Colore + ".png", UriKind.Relative));
      var oldColor = _dockPanel.Background;
      _dockPanel.Children.Clear();
      _dockPanel = null;
      _dockPanel = new DockPanel();
      //_dockPanel.Background = oldColor;
      _dockPanel.Children.Add(_image);
      //AssociateButton.Background = newCase.ButtonCase.Background;
      //AssociateButton.Content = _dockPanel;
      newCase.ButtonCase.Content = _dockPanel;
      AssociateButton = newCase.ButtonCase;
      //newCase.ButtonCase.Background = Brushes.Black;

      var destinationCase = "__";
      var deletedPawn = MainWindowParent.GetPawn(newCase.CaseName);
      if (deletedPawn != null)
      {
        //suppression
        MainWindowParent.PawnList.Remove(deletedPawn);
        MainWindowParent.PawnListBlack = null;
        MainWindowParent.PawnListBlack = new List<Pawn>();
        MainWindowParent.PawnListWhite = null;
        MainWindowParent.PawnListWhite = new List<Pawn>();
        MainWindowParent.PawnListBlack = MainWindowParent.PawnList.Where(x => x.Colore == "Black").ToList();
        MainWindowParent.PawnListWhite = MainWindowParent.PawnList.Where(x => x.Colore == "White").ToList();
        /*if(deletedPawn.Colore == "White")
          MainWindowParent.PawnListBlack.Remove(deletedPawn);
        else
          MainWindowParent.PawnListWhite.Remove(deletedPawn);*/
        if (deletedPawn.Name == "King")
          MainWindowParent.Win(this.Colore);
        MainWindowParent.AddDeadList(deletedPawn.Name + deletedPawn.Colore);

        destinationCase = GetNameAndColor(deletedPawn);
      }

      //X = newCase.X;
      //Y = newCase.Y;
      IsFirstMove = false;
      this.Location = newCase.CaseName;
      this.X = newCase.X;
      this.Y = newCase.Y;







      //Debug.WriteLine("nove: new position = " + this.Location);
      //var name = AddSpaceInEnd(this.Name,10);
      var name = this.Name;
      if (name == "SimplePawn")
        name = "Pawn";

      var line = "";
      if (!String.IsNullOrEmpty(MainWindowParent.DebugTextBlock.Text))
        line += $"\n";
      line += $"{MainWindowParent.CurrentTurn}:\t{name}\t{oldLocation} => {this.Location}";
  
      MainWindowParent.DebugTextBlock.Text += $"{line}";
      
      MainWindowParent.AppEndInPartHistory(line);
      
      MainWindowParent.SaveHistoryToFileButton.IsEnabled = true;
      MainWindowParent.ScrollViewerDebugTextBlock.ScrollToEnd();
      //Rank
      if (this.Name == "SimplePawn" && (Y == "1" || Y == "8"))
      {
        //var riseInRankWindow = new RiseInRankWindow(this);
        // riseInRankWindow.ShowDialog();

        //AUTOMATIC SWITH
        this.SwithTo("Queen");

      }

      //Roc
      if (this.Name == "King" && this.IsFirstMoveKing && this.IsLeftRookFirstMove && this.X == "c")
      {
        var rook = MainWindowParent.GetLeftRook(this.Colore);
        if (rook != null)
        {
          rook.Move(MainWindowParent.GetCase("d" + Y));
          MainWindowParent.SwithTurnAsync();
        }

      }
      if (this.Name == "King" && this.IsFirstMoveKing && this.IsRightRookFirstMove && this.X == "g")
      {
        var rook = MainWindowParent.GetRightRook(this.Colore);
        if (rook != null)
        {
          rook.Move(MainWindowParent.GetCase("f" + Y));
          MainWindowParent.SwithTurnAsync();
        }

      }

      if (this.Name == "King")
        IsFirstMoveKing = false;


      //remplissage de MovingList
      if (Chess2Console.Utils.MovingList == null)
        Chess2Console.Utils.MovingList = new List<string>();
      //Chess2Console.Utils.MainBord
      //Ajout du mouvement

      var initialIndex = Chess2Utils.GetIndexFromLocation(oldLocation);
      var destinationIndex = Chess2Utils.GetIndexFromLocation(newCase.CaseName);
      var initialCase = GetNameAndColor(this);

      Chess2Console.Utils.MovingList.Add($"{initialIndex.ToString()}({initialCase})>{destinationIndex.ToString()}({destinationCase})");



      //on recalcure la valeurs du pion en fonction de sa nouvelle position
      // SetValue();



      //si le roi se deplace de deux case vers la gauche ou la droite
      //et le fou se place à droite ou à gauche du roi

      MainWindowParent.FillAllPossibleTrips();
      this.MaxScore = 0;
      this.EvaluateScorePossibleTrips();

      MainWindowParent.SetDefaultColoreAllCases();

      //MainWindowParent.SetDefaultColoreAllCases();
      MainWindowParent.SetOldPositionColore(oldLocation);

      //on colore aussi la nouvelle case
      //ButtonCase
      AssociateButton.Background = Brushes.Pink;
      MainWindowParent.SwithTurnAsync();
    }

    /*tsiry;17-11-2021
     * pour prendre le nom du pion et sa couleur sous la forme:
     * 48(P|W)>42(P|B))
     * */
    public string GetNameAndColor(Pawn pawn)
    {
      var pawnName = "";
      if (pawn.Name == "Bishop")
      {
        pawnName = "B";

      }
      if (pawn.Name == "King")
      {
        pawnName = "K";
      }
      if (pawn.Name == "Queen")
      {
        pawnName = "Q";
      }
      if (pawn.Name == "Rook")
      {
        pawnName = "T";
      }
      if (pawn.Name == "Knight ")
      {
        pawnName = "C";
      }
      if (pawn.Name == "SimplePawn")
      {
        pawnName = "P";
      }



      var caseColor = "";
      if (pawn.Colore == "Black")
      {
        caseColor = "B";
      }
      else
      {

        caseColor = "W";
      }

      return $"{pawnName}|{caseColor}";
    }

    public string AddSpaceInEnd(string strIn,int length)
    {
      var strInLength = strIn.Length;

      if (length < strInLength)
        return "ERROR";

      if (length == strInLength)
        return strIn;
      var spaceNumber = length - strInLength;
      var strOut = strIn;
      for (int i = 0; i < spaceNumber; i++)
      {
        strOut += " ";
      }
      if (strIn == "King")
        strOut += " ";
      return strOut;
    }




    public void SwithTo(string name)
    {
      this.Name = name;
      SetValue();
      _image = null;
      _image = new Image();
      _image.Height = 60;
      _image.Width = 60;
      _image.Source = new BitmapImage(new Uri(@"/Images/" + Name + Colore + ".png", UriKind.Relative));
      var oldColor = _dockPanel.Background;
      _dockPanel.Children.Clear();
      _dockPanel = null;
      _dockPanel = new DockPanel();
      //_dockPanel.Background = oldColor;
      _dockPanel.Children.Add(_image);
      //AssociateButton.Background = newCase.ButtonCase.Background;
      //AssociateButton.Content = _dockPanel;
      this.AssociateButton.Content = _dockPanel;

    }

  }
}
