using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Chess.Entity;
using Chess.Utils;

namespace Chess.Model
{
  public class ServiceChessDB
  {

    
    public bool CreateNewGamePart(string gamePartLabel,DateTime startingDateTime,string gamePartMode)
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {
          var newGamePart = new GamePart();
          newGamePart.GamePartLabel = gamePartLabel;
          newGamePart.GamePartStartDateTime = startingDateTime;
          newGamePart.GamePartMode = gamePartMode;
          chessBDEntitie.GamePart.Add(newGamePart);
          chessBDEntitie.SaveChanges();
        }
        return true;

      }
      catch (Exception ex)
      {

        MessageBox.Show($"Error DB {ex.ToString()}");
        return false;
      }
    }

    public GamePart GetLastGamePart()
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {
          return chessBDEntitie.GamePart.ToList().Last();
        }
      }
      catch (Exception ex)
      {

        MessageBox.Show($"Error DB {ex.ToString()}");
        return null;
      }
    }
    public int InserTurn(long gamePartID,List<Pawn> pawnList,string currentTurn)
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {
          var newTurn= new Turns();
          newTurn.GamePart = chessBDEntitie.GamePart.First(x => x.GamePartID== gamePartID);
          newTurn.TurnColor = currentTurn;
          var pawnListStr = "";
          foreach (var pawn in pawnList)
          {
            pawnListStr+=$"{pawn.Name};{pawn.Location};{pawn.Colore};{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}\n";
          }
          newTurn.PawnListStr = pawnListStr;
          newTurn.InserionDateTime = DateTime.Now;

          newTurn.GamePart.Turns.Add(newTurn);
          chessBDEntitie.SaveChanges();
          return newTurn.GamePart.Turns.Count();
        }
      }
      catch (Exception ex)
      {

        MessageBox.Show($"Error DB {ex.ToString()}");
        return -1;
      }
    }
   
    public bool AddBestPositionsFor(long? turnID,string color, int weight)
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {
          var turn = chessBDEntitie.Turns.FirstOrDefault(x => x.TurnID == turnID);
          if (turn == null)
            return false;
          turn.BestPositionsFor = color;
          turn.BestPositionsWeight = weight;
          chessBDEntitie.SaveChanges();

          //modification de GamePart
          var gamePart = turn.GamePart;
          if(!gamePart.GamePartLabel.Contains("*"))
          {
            gamePart.GamePartLabel = $"{gamePart.GamePartLabel}*";
          }
          chessBDEntitie.SaveChanges();
          return true;

        }
      }
      catch (Exception ex)
      {

        MessageBox.Show($"Error DB {ex.ToString()}");
        return false;
      }
    }

    public bool DeleteBestPostion(long turnID)
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {
          var turn = chessBDEntitie.Turns.FirstOrDefault(x => x.TurnID == turnID);
          if (turn == null)
            return false;
          turn.BestPositionsFor = null;
          turn.BestPositionsWeight = null;
          chessBDEntitie.SaveChanges();

          //modification de GamePart
          var bestPostions = turn.GamePart.Turns.FirstOrDefault(x => x.BestPositionsFor != null);
          if(bestPostions== null)
          {
            turn.GamePart.GamePartLabel= turn.GamePart.GamePartLabel.Replace("*", "");
          }
          chessBDEntitie.SaveChanges();
          
        }

        return true;
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error DB {ex.ToString()}");
        return false;
      }
    }
    public GamePart GetGamePart(long gamePartID)
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {
          return chessBDEntitie.GamePart.FirstOrDefault(x => x.GamePartID == gamePartID);
        }
      }
      catch (Exception ex)
      {

        MessageBox.Show($"Error DB {ex.ToString()}");
        return null;
      }
    }
    
    public List<GamePart> GetValidGameParts(string gamePartMode)
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {
          return chessBDEntitie.GamePart.Where(x=>x.GamePartMode == gamePartMode && x.Turns.Count>0).OrderByDescending(x=>x.GamePartID).ToList();
        }
      }
      catch (Exception ex)
      {

        MessageBox.Show($"Error DB {ex.ToString()}");
        return null;
      }
    }

    public List<Turns> GetGameTurns(long gamePartID)
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {

          return chessBDEntitie.Turns.Where(x => x.GamePartID == gamePartID).ToList();
        }
      }
      catch (Exception ex)
      {

        MessageBox.Show($"Error DB {ex.ToString()}");
        return null;
      }
    }

    public List<VBestPostions> GetVBestPostions()
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {
          return chessBDEntitie.VBestPostions.ToList();
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error DB {ex.ToString()}");
        return null;

      }
    }

    public VBestPostions GetVBestPostion(long TurnID)
    {
      try
      {
        using (var chessBDEntitie = new ChessDBEntities())
        {
          return chessBDEntitie.VBestPostions.FirstOrDefault(x=>x.TurnID == TurnID);
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error DB {ex.ToString()}");
        return null;

      }
    }
   

  }
}
