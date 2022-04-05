using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess.Utils
{
  public class Case
  {
    public MainWindow MainWindowParent { get; set; }
    public string X { get; set; } //a - h
    public string Y { get; set; } //1 - 8
    public Button ButtonCase { get; set; }
    public string CaseName { get; set; }

    public int Score { get; set; }





    public Case(string x,string y, Button buttonCase, MainWindow mainWindowParent)
    {
      Score = 0;
      MainWindowParent = mainWindowParent;
      X = x;
      Y = y;
      CaseName = X + Y;
      ButtonCase = buttonCase;

      SetDefaultColore();







      ButtonCase.Click += buttonCase_Click;
    }

    public void SetDefaultColore()
    {

      var oldContent = ButtonCase.Content;
      ButtonCase.Background = Brushes.Blue;
      var xasciiCode = (int)Convert.ToChar(X);
      var yint = Int32.Parse(Y);
      if ((xasciiCode % 2) == 1 && (yint % 2) == 0)
        ButtonCase.Background = Brushes.Red;
      if ((xasciiCode % 2) == 0 && (yint % 2) == 1)
        ButtonCase.Background = Brushes.Red;


      var dockPanel = new DockPanel();
      var label = new Label();
      label.Content = Chess2Utils.GetIndexFromLocation(CaseName);
     dockPanel.Children.Add(label);
      if(MainWindowParent.PawnList.FirstOrDefault(x=>x.Location == CaseName)==null)
        ButtonCase.Content = dockPanel;
      else
        ButtonCase.Content = oldContent;
    }
    public void SetOldPositionColore()
    {
      ButtonCase.Background = Brushes.Pink;
     
    }

    private void buttonCase_Click(object sender, EventArgs e)
    {
      //MOVE dase de depar, case d'arriver
      var buttonSender = (Button)sender;
      var senderGetPawn = MainWindowParent.GetPawn(buttonSender.Name);

     

      if(senderGetPawn != null)//selection d'un pion ou attaque sur in pion adverse
      {
        //case de depar
        // MainWindowParent.ToPosition ="";

        var currentPawn = MainWindowParent.GetPawn(MainWindowParent.FromPosition);
        var opinonPawn = MainWindowParent.GetPawn(buttonSender.Name);
        if(currentPawn != null && opinonPawn !=null)//attaque
        {
          MainWindowParent.MoveTo(MainWindowParent.FromPosition, buttonSender.Name);
            return;
        }

        MainWindowParent.FromPosition = buttonSender.Name;
        senderGetPawn.EvaluateScorePossibleTrips();
        senderGetPawn.ColorAvaleblesCases();
        return;
      }
      else
      {
        MainWindowParent.SetDefaultColoreAllCases();
        MainWindowParent.ToPosition = buttonSender.Name;
      }

      if(!String.IsNullOrEmpty(MainWindowParent.FromPosition) && !String.IsNullOrEmpty(MainWindowParent.ToPosition))
      {
        MainWindowParent.MoveTo(MainWindowParent.FromPosition, MainWindowParent.ToPosition);
      }

      


    }

    public void Evaluate(string startPosition)
    {
      //la note est écaluer en fonction du piece présente
      var whiteScore = 0;
      var blackScore = 0;

      var pawn = MainWindowParent.GetPawn(this.CaseName);
      if (pawn == null)
      {
        whiteScore = blackScore = 0;
      }
      else
      {
        if (pawn.Colore == "White")
          whiteScore = pawn.Value;
        else
          blackScore = pawn.Value;
      }

     




    }

  }
}
